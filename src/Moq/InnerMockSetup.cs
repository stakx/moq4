// Copyright (c) 2007, Clarius Consulting, Manas Technology Solutions, InSTEDD.
// All rights reserved. Licensed under the BSD 3-Clause License; see License.txt.

namespace Moq
{
	internal sealed class InnerMockSetup : SetupWithOutParameterSupport, IDeterministicReturnValueSetup
	{
		private readonly object returnValue;

		public InnerMockSetup(InvocationShape expectation, object returnValue)
			: base(expectation)
		{
			this.returnValue = returnValue;
		}

		public object ReturnValue => this.returnValue;

		public override void Execute(Invocation invocation)
		{
			invocation.Return(this.returnValue);
		}

		public override MockException TryVerify()
		{
			return this.TryVerifyInnerMock(innerMock => innerMock.TryVerify());
		}

		public override MockException TryVerifyAll()
		{
			return this.TryVerifyInnerMock(innerMock => innerMock.TryVerifyAll());
		}
	}
}