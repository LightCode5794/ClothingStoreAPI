﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Common
{


    public enum StautusProduct
    {
        published,
        pending,
        deleted,
    }
    public enum StatusOder
    {
        PENDING,
        CONFIRMED,
        OUT_FOR_DELIVERY,
        DELIVERED,
        CANCELLED,
    }

}
