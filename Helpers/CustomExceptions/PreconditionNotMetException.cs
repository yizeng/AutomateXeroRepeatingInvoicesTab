using System;
using System.Runtime.Serialization;

namespace Helpers.CustomExceptions {

	[Serializable]
	public class PreconditionNotMetException : Exception {

		public PreconditionNotMetException() {
		}

		public PreconditionNotMetException(string message)
			: base(message) {
		}

		public PreconditionNotMetException(string message, Exception inner)
			: base(message, inner) {
		}

		public PreconditionNotMetException(SerializationInfo info, StreamingContext context)
			: base(info, context) {
		}
	}
}
