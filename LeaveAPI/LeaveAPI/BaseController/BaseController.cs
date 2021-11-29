using LeaveAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LeaveAPI.BaseController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<Entity> Get()
        {
            var result = repository.Get();
            if (result.Count() <= 0)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = $"Data Belum Ada" });
            }
            /*return Ok(result);*/
            return Ok(new { status = HttpStatusCode.OK, result = result, message = $"Data berhasil ditampilkan" });
        }

        [HttpGet("{Key}")]
        public ActionResult Get(Key key)
        {
            try
            {
                var result = repository.Get(key);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok(new { status = HttpStatusCode.InternalServerError, result = "", message = "Data Tidak Ditemukan" });
            }

        }

        [HttpPost]
        public ActionResult Insert(Entity entity)
        {
            try
            {
                var result = repository.Insert(entity);
                return Ok(new { status = HttpStatusCode.OK, result, message = "Data Berhasil Ditambahkan" });
            }
            catch (Exception)
            {
                return Ok(new { status = HttpStatusCode.InternalServerError, result = "", message = "Data Gagal Ditambahkan" });
            }
        }
        /*public ActionResult Post(Entity entity)
        {
            var result = repository.Insert(entity);
            return Ok(new { status = HttpStatusCode.OK, result = result, message = "Data Berhasil Ditambahkan" });
            *//*return Ok(result);*//*
        }*/

        [HttpDelete("{Key}")]
        public ActionResult Delete(Key key)
        {
            try
            {
                var result = repository.Delete(key);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok(new { status = HttpStatusCode.InternalServerError, result = "", message = "Data Tidak Ditemnukan" });
            }
        }

    }
}
