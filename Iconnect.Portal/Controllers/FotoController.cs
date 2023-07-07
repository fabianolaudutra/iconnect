using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FotoController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<FotoController> _logger;

        public FotoController(ILogger<FotoController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;
        }

        public class Upload
        {
            public string data { get; set; }
            public IFormFile file { get; set; }
        }

        [HttpPost]
        [Authorize]
        [Route("upload/{id}")]
        public IActionResult uploadFoto(string id)
        {
            try
            {
                var file = Request.Form.Files[0];
                byte[] ImageByte = null;
                if (file == null) throw new Exception("File is null");
                if (file.Length == 0) throw new Exception("File is empty");

                Bitmap source = new Bitmap(file.OpenReadStream());

                Bitmap target;                
                if(source.Width > source.Height)
                    target = new Bitmap(320, 215);
                else
                    target = new Bitmap(215, 320);

                using (Graphics g = Graphics.FromImage(target))
                {
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(source, 0, 0, target.Width, target.Height);
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    target.Save(ms, ImageFormat.Jpeg);
                    ImageByte = ms.ToArray();
                }

                var result = _service.Foto.uploadFoto(id, ImageByte);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Authorize]
        [Route("SalvarFoto")]
        public IActionResult SalvarFoto([FromBody] SalvarFotoViewModel obj)
        {
            try
            {
                if (obj == null)
                    throw new Exception();
                if (string.IsNullOrEmpty(obj.Imagem))
                    throw new Exception();

                var bytes = Convert.FromBase64String(obj.Imagem);
                var result = _service.Foto.uploadFoto(obj.Id, bytes);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Authorize]
        [Route("getFoto/{id}")]
        public RetornoFotoViewModel GetFoto(int id)
        {
            return _service.Foto.GetFoto(id);
        }

        [HttpPost]
        [Authorize]
        [Route("getFotos")]
        public IList<byte[]> GetFotos([FromBody] int[] ids)
        {
            var retorno = new List<byte[]>();

            if (ids?.Any() ?? false)
            {
                foreach (var id in ids)
                {
                    var foto = _service.Foto.GetFoto(id);

                    retorno.Add(foto.Imagem);
                }
            }

            return retorno;
        }

        [HttpGet]
        [Route("deleteFoto/{id}")]
        public IActionResult DeleteFoto(int id)
        {
            return Ok(_service.Foto.DeletarFoto(id));
        }
    }
}