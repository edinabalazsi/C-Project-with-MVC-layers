using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeaHouse.Logic;
using TeaHouse.Web.Models;

namespace TeaHouse.Web.Controllers
{
    public class ExtrasApiController : ApiController
    {
        public class ApiResult
        {
            public bool OperationResult { get; set; }
        }

        ILogic logic;
        IMapper mapper;

        public ExtrasApiController()
        {
            logic = new Logic.Logic();
            mapper = MapperFactory.CreateMapper();
        }

        // GET api/ExtrasApi/all
        [ActionName("all")]
        [HttpGet]
        public IEnumerable<Models.Extra> GetAll()
        {
            var extras = logic.GetAllExtras();
            return mapper.Map<IList<Data.EXTRA>, List<Models.Extra>>(extras);
        }

        // GET api/ExtrasApi/del
        [ActionName("del")]
        [HttpGet]
        public ApiResult DelOneExtra(int id)
        {
           return new ApiResult() { OperationResult = logic.RemoveExtra(id) };

        }

        // POST api/ExtrasApi/add + extra
        [HttpPost]
        [ActionName("add")]
        public ApiResult AddOneExtra(Extra extra)
        {
            logic.AddExtra(extra.Category, extra.ExtraName,extra.Allergen, extra.Available, extra.Price);
            return new ApiResult() { OperationResult = true };
        }

        // POST api/ExtrasApi/mod  + extra
        [HttpPost]
        [ActionName("mod")]
        public ApiResult ModOneExtra(Extra extra)
        {
            return new ApiResult()
            {
                OperationResult = logic.ChangeExtra(extra.Id, extra.Category, extra.ExtraName, extra.Allergen, extra.Available, extra.Price)
            };
        }
    }
}
