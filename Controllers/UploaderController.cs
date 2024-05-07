using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using saveimage.Model;

namespace saveimage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploaderController : ControllerBase
    {
        [HttpPost]
        [Route("uploadfiles")]
        public Response UploadFile([FromForm] FileModel fileModel)
        {
            Response response = new Response();
            try
            {
                string path = Path.Combine(@"C:\Users\VideAlpha\Pictures\my images", fileModel.FileName);
                using (Stream stream=new FileStream(path, FileMode.Create))
                {
                    fileModel.file.CopyTo(stream);
                }
                response .StatusCode = 200;
                response.Message = "Image created Successfully";

            }
            catch (Exception ex)
            {
                response.StatusCode = 100;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
