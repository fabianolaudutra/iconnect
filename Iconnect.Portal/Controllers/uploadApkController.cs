using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iconnect.Aplicacao;
using Iconnect.Aplicacao.ViewModels;
using Iconnect.Aplicacao.FilterModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;


namespace Iconnect.Portal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class uploadApkController : PadraoController
    {
        private readonly IServiceWrapper _service;

        private readonly ILogger<uploadApkController> _logger;

        public uploadApkController(ILogger<uploadApkController> logger, IServiceWrapper service, IHttpContextAccessor acessor) : base(acessor)
        {
            _logger = logger;
            _service = service;

        }


        [Authorize]
        [Route("salvar")]
        [HttpPost]
        public IActionResult Post([FromBody] UploadAPK model)
        {
            try
            {
                string path = "C:\\apk";//$"{Directory.GetCurrentDirectory()}{@"C:\\apk"}";
                DirectoryInfo dir = new DirectoryInfo(path);
                byte[] array = null;
                foreach (FileInfo t in dir.GetFiles())
                {
                    array = new byte[t.Length];
                }
                //model.upa_c_arquivo = array;

                return Ok(_service.UploadAPK.SalvarAPK(model, UsuarioLogado));
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        [HttpGet]
        [Authorize]
        [Route("editar/{id}")]
        public UploadAPK Get(int id)
        {
            return _service.UploadAPK.GetAPK(id);
        }

        [HttpGet]
        [Authorize]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_service.UploadAPK.DeletarAPK(id));
        }


        [HttpGet]
        [Authorize]
        [Route("deletarAll")]
        public IActionResult deletarAll()
        {
            return Ok(_service.UploadAPK.deletarAll());
        }


        [HttpPost]
        [Authorize]
        [Route("buscarFiltrado")]
        public IActionResult GetFiltered([FromBody] UploadApkFilterModel filter)
        {
            var response = _service.UploadAPK.GetApkFiltrado(filter);
            return Ok(new PagedResponse<IPagedList<UploadAPK>>() { Data = response, Total = response.TotalItemCount });
        }
        [HttpPost]
        [Authorize]
        [RequestFormLimits(ValueLengthLimit = 737280000, MultipartBodyLengthLimit = 737280000)]
        [RequestSizeLimit(737280000)]
        [DisableRequestSizeLimit]
        [Route("upload")]
        public async Task<IActionResult> uploadFoto()
        {
            try
            {
                var file = Request.Form.Files[0];
                string baseDirectory = "C:\\";
                var folderName = Path.Combine("apk");
                var pathToSave = Path.Combine(baseDirectory, folderName);
                if (file.Length > 0)
                {
                    if (!Directory.Exists(pathToSave)) Directory.CreateDirectory(pathToSave);

                 //Deletar arquivo
                 DirectoryInfo dir = new DirectoryInfo(pathToSave);
                  if (dir.Exists)
                  {
                   foreach (FileInfo f in dir.GetFiles())
                    {
                      f.Delete();
                    }
                   }
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave, filename.Replace("\"", " ").Trim());

                    
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        var binaryReader = new BinaryReader(stream);
                    }
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return BadRequest();
        }
        public class Upload
        {
            public string data { get; set; }
            public IFormFile file { get; set; }
        }
    }
}