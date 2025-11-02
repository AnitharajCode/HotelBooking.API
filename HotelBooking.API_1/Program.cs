using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HotelBooking.BusinessLogicLayer;
using HotelBooking.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);
