﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Ofl.Google;
using Ofl.YouTube.V3;

namespace Ofl.YouTube
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddYouTubeClient(
            this IServiceCollection serviceCollection
        )
        {
            // Validate parameters.
            var sc = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));

            // Add the YouTube client.
            sc.AddHttpClient<IYouTubeClient, YouTubeClient>()
                .ConfigureGoogleApiKeyProvider();

            // Return the service collection.
            return sc;
        }
    }
}
