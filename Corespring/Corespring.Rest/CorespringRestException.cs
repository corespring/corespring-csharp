using System;
using Corespring.Resources;

namespace Corespring.Rest
{
    /**
     * This Exception is designed to catch known errors that are returned from the CoreSpring API. CoreSpring API
     * errors come in the following JSON format:
     * 
     *   {
     *     "code": 102,
     *     "message": "The Access Token is invalid or has expired",
     *     "moreInfo": ""
     *   }
     */
    public class CorespringRestException : Exception
    {
        private const int invalidOrExpiredAccessToken = 102;
        private const int expiredAccessToken = 108;

        private int[] invalidAccessToken = new int[] { invalidOrExpiredAccessToken, expiredAccessToken };

        public readonly int? errorCode;
        public readonly string errorMessage;

        public CorespringRestException(Error error)
        {
            this.errorCode = error.code;
            this.errorMessage = error.message;
        }

        public CorespringRestException(string responseBody)
        {
            this.errorMessage = responseBody;
            this.errorCode = null;
        }

        public bool hasErrorCode()
        {
            return this.errorCode != null;
        }

        /**
         * Returns true if the exception was generated as a result of an invalid access token, false otherwise.
         */
        public bool isInvalidAccessToken() {
            foreach (int invalidCode in invalidAccessToken) {
                if (this.errorCode == invalidCode) {
                    return true;
                }
            }
            return false;
        }
    }
}

