﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RannaTask2.Business.Dtos
{
	public class ProductDTO
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Code { get; set; }

		public decimal Price { get; set; }

		[Required]
		public string ImageUrl { get; set; }
	}
}
