using LearningCSharp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LearningCSharp.Data
{
    public class LearningCSharpDBContext : DbContext
    {
        public LearningCSharpDBContext() : base("DefaultConnection") { }
    }
}