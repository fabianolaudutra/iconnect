/** 
 *=================WebSocket based Player
 *
 */

/** 
 * Interface with h5s websocket player API
 * @constructor
 * @param {string} videoId - id of the video element tag
*/

function H5sPlayerWS(videoId) {

  this.sourceBuffer;
  this.buffer = [];
  this.mediaSource;
  this.video;
  this.wsSocket;
  this.checkSourceBufferId;
  this.keepaliveTimerId;
  this.emptyBuffCnt = 0;
  this.lastBuffTime = 0;
  this.buffTimeSameCnt = 0;
  this.bNeedReconnect = false;

  this._videoId = videoId;
  this._token;
  this._porta;
}

H5sPlayerWS.prototype.ReconnectFunction = function () {
  //console.log('Try Reconnect...', this.bNeedReconnect);
  if (this.bNeedReconnect === true) {
      //console.log('Reconnect...');
      this.setupSourceBuffer(this.videoId);
      this.setupWebSocket(this._token, this._porta);
      this.bNeedReconnect = false;
  }
  //console.log('Try Reconnect...', this.bNeedReconnect);
}


H5sPlayerWS.prototype.H5SWebSocketClient = function (h5spath, porta) {
  var socket;
  //console.log("H5SWebSocketClient");
  //console.log(window.location.protocol);
  try {
      if (window.location.protocol == "http:") {
          if (typeof MozWebSocket != "undefined") {
              socket = new MozWebSocket('ws://192.91.254.123:' + porta + h5spath);
          } else {
              socket = new WebSocket('ws://192.91.254.123:' + porta + h5spath);
          }
      }
      if (window.location.protocol == "https:") {
          //alert(window.location.host);
          //console.log(window.location.host);
          if (typeof MozWebSocket != "undefined") {
              socket = new MozWebSocket('wss://192.91.254.123:' + porta + h5spath);
          } else {
              socket = new WebSocket('wss://192.91.254.123:' + porta + h5spath);
          }
      }
      //console.log(window.location.host);
  } catch (e) {
      console.log('Erro: ');
      console.log(e);
      return;
  }
  return socket;
}


H5sPlayerWS.prototype.readFromBuffer = function () {
  if (this.buffer.length === 0 || this.sourceBuffer.updating) {
      return;
  }
  try {
      var data = this.buffer.shift();
      var dataArray = new Uint8Array(data);
      this.sourceBuffer.appendBuffer(dataArray);
  } catch (e) {
    console.log('Erro: ');
    console.log(e);
  }
}
H5sPlayerWS.prototype.keepaliveTimer = function () {

  if(this.wsSocket != null && this.wsSocket.readyState != WebSocket.CLOSED && this.wsSocket.readyState != WebSocket.CLOSING)
    this.wsSocket.send("keepalive");
}

H5sPlayerWS.prototype.onWebSocketData = function (msg) {
  /*
      var blob = msg.data;
  
      var fileReader = new FileReader();
      fileReader.onload = function () {
          this.buffer.push(this.result);
          readFromBuffer();
      };
  
      fileReader.readAsArrayBuffer(blob);
      */
  this.buffer.push(msg.data);
  this.readFromBuffer();
}


H5sPlayerWS.prototype.setupSourceBuffer = function () {
  window.MediaSource = window.MediaSource || window.WebKitMediaSource;
  if (!window.MediaSource) {
      console.log('MediaSource API is not available');
  }

  this.mediaSource = new window.MediaSource();

  this.video = document.getElementById(this._videoId);
  this.video.autoplay = true;
  //console.log(this._videoId);

  //var h5spath = video.getAttribute('h5spath');
  var h5spath = "/h5swsapi";


  /* var video = document.querySelector('h5sVideo'); */
  //alert(h5spath);
  this.video.src = window.URL.createObjectURL(this.mediaSource);
  this.video.play();

  this.mediaSource.addEventListener('sourceopen', this.mediaSourceOpen.bind(this), false);

}

H5sPlayerWS.prototype.mediaSourceOpen = function () {
  //console.log("Add SourceBuffer");
  //var strCodec = 'video/mp4; codecs="avc1.420028"';
  //var strCodec = 'video/mp4; codecs="avc1.42E01E"';
  var strCodec = 'video/mp4; codecs="avc1.640029"';
  this.sourceBuffer = this.mediaSource.addSourceBuffer(strCodec);
  this.mediaSource.duration = Infinity;
  this.mediaSource.removeEventListener('sourceopen', this.mediaSourceOpen, false);
  this.sourceBuffer.addEventListener('updateend', this.readFromBuffer.bind(this), false);
}

H5sPlayerWS.prototype.setupWebSocket = function (token, porta) {
  this.video = document.getElementById(this._videoId);
  this.video.autoplay = true;

  //var h5spath = this.video.getAttribute('h5spath');
  var h5spath = "/h5swsapi";
  //var token = this.video.getAttribute('token');
  h5spath = h5spath + "?token=" + token;
  //console.log(h5spath);

  this.wsSocket = this.H5SWebSocketClient(h5spath, porta);
  //console.log("setupWebSocket", this.wsSocket);
  this.wsSocket.binaryType = 'arraybuffer';
  this.wsSocket.onmessage = this.onWebSocketData.bind(this);
  
  this.wsSocket.h5 = this;
  this.wsSocket.onopen = function () {
      this.h5.checkSourceBufferId = setInterval(this.h5.CheckSourceBuffer.bind(this.h5), 3000);
      this.h5.keepaliveTimerId = setInterval(this.h5.keepaliveTimer.bind(this.h5), 1000);
  }

  this.wsSocket.onclose = function () {
      this.h5.CleanupWebSocket();
      this.h5.CleanupSourceBuffer();
      this.h5.bNeedReconnect = true;
  }  
}

H5sPlayerWS.prototype.CleanupSourceBuffer = function () {
  //console.log('Cleanup Source Buffer', this);
  this.sourceBuffer.removeEventListener('updateend', this.readFromBuffer, false);
  this.sourceBuffer.abort();

  if (document.documentMode || /Edge/.test(navigator.userAgent)) {
      console.log('IE or EDGE!');
  } else {
      this.mediaSource.removeSourceBuffer(this.sourceBuffer);
  }
  //Clear the this.video source
  //this.video.src = '';
  this.sourceBuffer = null;
  this.mediaSource = null;
  this.buffer = [];

}

H5sPlayerWS.prototype.CleanupWebSocket = function () {
  //console.log('CleanupWebSocket', this);
  clearInterval(this.keepaliveTimerId);
  clearInterval(this.checkSourceBufferId);
  this.emptyBuffCnt = 0;
  this.lastBuffTime = 0;
  this.buffTimeSameCnt = 0;
}


H5sPlayerWS.prototype.CheckSourceBuffer = function () {
  //console.log("CheckSourceBuffer", this);
  if (this.sourceBuffer.buffered.length <= 0) {
      this.emptyBuffCnt++;
      if (this.emptyBuffCnt > 8) {
          //console.log("CheckSourceBuffer Close 1");
          this.wsSocket.close();
          return;
      }
  } else {
      this.emptyBuffCnt = 0;
      var buffStartTime = this.sourceBuffer.buffered.start(0);
      var buffEndTime = this.sourceBuffer.buffered.end(0);

      var buffDiff = buffEndTime - this.video.currentTime;
      if (buffDiff > 5 || buffDiff < 0) {
          //console.log("CheckSourceBuffer Close 2");
          this.wsSocket.close();
          return;
      }

      if (buffEndTime == this.lastBuffTime) {
          this.buffTimeSameCnt++;
          if (this.buffTimeSameCnt > 3) {
              //console.log("CheckSourceBuffer Close 3");
              this.wsSocket.close();
              return;
          }
      } else {
          this.buffTimeSameCnt = 0;
      }

      this.lastBuffTime = buffEndTime;

  }

}

/** 
* Connect a websocket Stream to videoElement 
* @param {string} id - id of WebRTC stream
*/
H5sPlayerWS.prototype.connect = function (id, porta) {

  this._token = id;
  this._porta = porta;
  this.setupSourceBuffer();

  /* start connect to server */
  this.setupWebSocket(id, porta);
  this.reconnectTimerId = setInterval(this.ReconnectFunction.bind(this), 3000);
}


/** 
* Disconnect a websocket Stream and clear videoElement source
*/
H5sPlayerWS.prototype.disconnect = function () {
  //console.log("disconnect", this.wsSocket);
  clearInterval(this.reconnectTimerId);

  if (this.wsSocket != null) {
      this.wsSocket.close();
      this.wsSocket = null;
  }
  //this.CleanupWebSocket();
  //this.CleanupSourceBuffer();
}