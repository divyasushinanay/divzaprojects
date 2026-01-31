using Domain.Services.Fees.DTO;
using Domain.Services.Fees.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SkillTrackPro.API.Fees
{

    using global::Domain.Enum;
    using global::Domain.Models;
    using global::Domain.Services.Studentz.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Domain.Services.Fees
    {
        [ApiController]
        [Route("api/fees")]
        public class FeeController : ControllerBase
        {
            private readonly IFeesService _feeService;

            public FeeController(IFeesService feeService)
            {
                _feeService = feeService;
            }

            // PAY FEE
            [HttpPost("pay/{parentId}")]
            public async Task<IActionResult> PayFee(Guid parentId, PayFeeRequestDto dto)
            {
                await _feeService.PayFee(parentId, dto);
                return Ok("Fee paid successfully");
            }

            // VIEW PARENT PAYMENTS
            [HttpGet("parent/{parentId}")]
            public async Task<IActionResult> GetParentPayments(Guid parentId)
            {
                var payments = await _feeService.GetParentPayments(parentId);
                return Ok(payments);
            }

            // VIEW STUDENTS WITH DUES (ADMIN)
            [HttpGet("dues")]
            public async Task<IActionResult> GetStudentsWithDues()
            {
                var dues = await _feeService.GetStudentsWithDues();
                return Ok(dues);
            }
        }
    }
}
