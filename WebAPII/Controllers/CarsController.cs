﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    { 
        ICarService _carService;

            public CarsController(ICarService carService)
            {
            _carService = carService;
            }
            [HttpGet("GetAll")]
            public IActionResult GetAll()
            {

                ICarService carservice = new CarManager(new EfCarDal());

                var result = carservice.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }

            [HttpPost("add")]

            public IActionResult Add(Car car)
            {

                var result = _carService.Add(car);

                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }



            [HttpGet("GetById")]
            public IActionResult Get(int id)
            {


                var result = _carService.GetById(id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
        }
    }

