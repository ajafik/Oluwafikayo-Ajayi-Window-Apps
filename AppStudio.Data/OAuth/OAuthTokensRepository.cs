using System.Collections.Generic;

namespace AppStudio.Data
{
    public static class OAuthTokensRepository
    {
        private static Dictionary<long, OAuthTokens> Tokens { get; set; }

        static OAuthTokensRepository()
        {
            Tokens = new Dictionary<long, OAuthTokens>();


            Tokens.Add(949, new OAuthTokens
                            {
                                { "ClientId", "7367644f257945898ea0656b06773f6b" }
                            });

            Tokens.Add(950, new OAuthTokens
                            {
                                { "ConsumerKey", "12RUPpteW6tTKsF7vEqM4y854" },
                                { "ConsumerSecret", "9Ul8a1BRg2RitpyuCtzov9vBLJvTn1OeCQaafqOuxaH3rkdZUH" },
                                { "AccessToken", "287817051-9iq0bv6hk5g1wqgWV1ovw4Q3DAJ3u7d0pU4KGc8Z" },
                                { "AccessTokenSecret", "3O9keLtKtvQdxa7lslrLjKWG0x8NBSugTA99Y2V5VU8sL" }
                            });

        }

        public static OAuthTokens GetTokens(long key)
        {
            if (Tokens.ContainsKey(key))
            {
                return Tokens[key];
            }
            return null;
        }

    }
}
