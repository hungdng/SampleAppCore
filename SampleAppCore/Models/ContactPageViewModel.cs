﻿using SampleAppCore.Service.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAppCore.Models
{
    public class ContactPageViewModel
    {
        public ContactViewModel Contact { set; get; }

        public FeedbackViewModel Feedback { set; get; }
    }
}
