﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSitterSharp;
public interface INativeConvertible<T> where T : struct
{
    unsafe T* ToUnmanaged();
}
