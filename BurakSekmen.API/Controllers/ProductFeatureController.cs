using AutoMapper;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BurakSekmen.API.Controllers
{
    [Authorize]
    public class ProductFeatureController : CustomBaseController
    {
        private readonly IProductFeatureService _productFeatureService;
        private readonly IMapper _mapper;

        public ProductFeatureController(IProductFeatureService productFeatureService, IMapper mapper)
        {
            _productFeatureService = productFeatureService;
            _mapper = mapper;
        }

       

    }
}
