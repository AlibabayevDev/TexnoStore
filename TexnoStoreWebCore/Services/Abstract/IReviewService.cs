﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStoreWebCore.Models;

namespace TexnoStoreWebCore.Services.Abstract
{
	public interface IReviewService
	{
        public double MiddleStarCount(int productId);
    }
}
