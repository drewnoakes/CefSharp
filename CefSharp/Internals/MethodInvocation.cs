// Copyright © 2010-2017 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System.Collections.Generic;

namespace CefSharp.Internals
{
    public sealed class MethodInvocation
    {
        public int BrowserId { get; private set; }

        public long FrameId { get; private set; }

        public long? CallbackId { get; private set; }

        public long ObjectId { get; private set; }

        public string MethodName { get; private set; }

        public List<object> Parameters { get; } = new List<object>();

        public MethodInvocation(int browserId, long frameId, long objectId, string methodName, long? callbackId)
        {
            BrowserId = browserId;
            FrameId = frameId;
            CallbackId = callbackId;
            ObjectId = objectId;
            MethodName = methodName;
        }
    }
}
