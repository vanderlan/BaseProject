﻿using AutoMapper;
using Invest.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Invest.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected AuthUser AuthUser => GetAuthenticatedUser();
        public ApiController(IMapper mapper)
        {
            _mapper = mapper;

            //   Mapper.AssertConfigurationIsValid();
        }

        private AuthUser GetAuthenticatedUser()
        {
            var email = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email);
            var givenName = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.GivenName);

            return new AuthUser
            {
                PublicId = User.Identity.Name,
                Email = email.Value,
                FisrtName = givenName.Value,
            };
        }
    }
}