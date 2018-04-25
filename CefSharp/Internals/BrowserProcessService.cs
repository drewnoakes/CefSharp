// Copyright © 2010-2017 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System.ServiceModel;

namespace CefSharp.Internals
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode=ConcurrencyMode.Multiple)]
    internal class BrowserProcessService : IBrowserProcess
    {
        private readonly JavascriptObjectRepository javascriptObjectRepository;
        private readonly BrowserProcessServiceHost host;
        
        public BrowserProcessService()
        {
            var context = OperationContext.Current;
            host = (BrowserProcessServiceHost)context.Host;

            javascriptObjectRepository = host.JavascriptObjectRepository;
        }

        public BrowserProcessResponse CallMethod(long objectId, string name, object[] parameters)
        {
            var success = javascriptObjectRepository.TryCallMethod(objectId, name, parameters, out var result, out var exception);

            return new BrowserProcessResponse { Success = success, Result = result, Message = exception };
        }

        public BrowserProcessResponse GetProperty(long objectId, string name)
        {
            var success = javascriptObjectRepository.TryGetProperty(objectId, name, out var result, out var exception);

            return new BrowserProcessResponse { Success = success, Result = result, Message = exception };
        }

        public BrowserProcessResponse SetProperty(long objectId, string name, object value)
        {
            var success = javascriptObjectRepository.TrySetProperty(objectId, name, value, out var exception);

            return new BrowserProcessResponse { Success = success, Result = null, Message = exception };
        }
    }
}
