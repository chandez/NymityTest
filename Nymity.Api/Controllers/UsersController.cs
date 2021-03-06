﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nymity.Core.Entities;
using Nymity.Core.Repositories;

namespace HttpRestApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        /// <summary>
        /// User repository
        /// </summary>
        private IUserRepository _userRepository;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="userRepository">User Repository.</param>
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get Users.
        /// </summary>
        /// <returns>User object.</returns>
        // GET: api/Users
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userRepository.Get();
            return Ok(users);
        }

        /// <summary>
        /// Get User by id.
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>User object</returns>
        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUsers")]
        public IActionResult Get(int id)
        {
            var user = _userRepository.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        // POST: api/Users
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
