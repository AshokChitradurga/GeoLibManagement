using GeoLib.Business.Entities;
using GeoLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoApplication.Controllers
{
    public class ZipCodeController : ApiController
    {
        //[HttpGet]
        //public IEnumerable<ZipCode> LoadAllZipCode()
        //{
        //    IZipCodeRepository zipCodeRepository = new ZipCodeRepository();
        //    return zipCodeRepository.SelectAllRecords();
        //}

        public HttpResponseMessage Get(string country = "all")
        {
            IZipCodeRepository zipCodeRepository = new ZipCodeRepository();
            switch (country.ToLower())
            {
                case "all":
                    return Request.CreateResponse(HttpStatusCode.OK,
                                zipCodeRepository.SelectAllRecords().Select(c => c.County));
                case "suffolk":
                    return Request.CreateResponse(HttpStatusCode.OK,
                                zipCodeRepository.SelectAllRecords().Where(st => st.County == country));
                default:
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Value should be all");
            }

        }

        [HttpGet]
        public ZipCode LoadZipCodeById(int id)
        {
            IZipCodeRepository zipCodeRepository = new ZipCodeRepository();
            return zipCodeRepository.SelectRecordByKey(id);
        }
    }
}
