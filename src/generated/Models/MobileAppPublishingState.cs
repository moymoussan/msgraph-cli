namespace ApiSdk.Models {
    /// <summary>Provides operations to manage the deviceAppManagement singleton.</summary>
    public enum MobileAppPublishingState {
        /// <summary>The app is not yet published.</summary>
        NotPublished,
        /// <summary>The app is pending service-side processing.</summary>
        Processing,
        /// <summary>The app is published.</summary>
        Published,
    }
}