using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.Repository;
namespace TMS.Controllers
{
    [Route("LonginAPI")]
    [ApiController]
    public class LonginAPIController : ControllerBase
    {
        public JWT jWT;

        /// <summary>
        /// 日志器
        /// </summary>
        private ILogger m_Logger;

        /// <summary>
        /// 日志器工厂
        /// </summary>
        private ILoggerFactory m_LoggerFactory;

        public LonginAPIController(JWT _jWT, ILoggerFactory loggerFactory)
        {
            jWT = _jWT;

            m_LoggerFactory = loggerFactory;
            // 获取指定名字的日志器
            m_Logger = m_LoggerFactory.CreateLogger("AppLogger");
        }

        LonginRepository longin = new LonginRepository();
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        [HttpPost, Route("LonGin")]
     
        public IActionResult LonGin(string Name=null,string Pass=null)
        {
            try
            {
                var list = longin.GetInfo(Name,Pass);
                if (list!=null)
                {
                    return Ok(new { data = list, token = jWT.GetJWT() });
                }
                else
                {
                    return Ok("登陆失败");
                }
            }
            catch (Exception ex)
            {
                m_Logger.LogError(ex, "捕捉到异常");
                return Ok("数据异常");
            }
        }
    }
}
