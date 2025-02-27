﻿using IO.Didomi.SDK.Events;
using IO.Didomi.SDK.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace IO.Didomi.SDK.Android
{
    /// <summary>
    /// Android implementation of the IDidomi interface
    /// This class uses JNI to make calls to the native Android SDK through the
    /// `AndroidJavaClass`, `AndroidJavaObject`, and `AndroidJavaProxy` classes.
    /// </summary>
    internal class AndroidDidomi : IDidomi
    {
        private const string PluginName = "io.didomi.sdk.Didomi";
        private const string UnityPlayerFullClassName = "com.unity3d.player.UnityPlayer";
		
		public AndroidDidomi()
        {
            OnReady(() => CallVoidMethod("setUserAgent", Package.GetInstance().agentName, Package.GetInstance().version));
        }

        public void AddEventListener(DidomiEventListener eventListener)
        {
            var eventListenerProxy = new EventListenerProxy(eventListener);

            CallVoidMethod("addEventListener", eventListenerProxy);
        }

        public ISet<Purpose> GetDisabledPurposes()
        {
            var obj = CallReturningJavaObjectMethod("getDisabledPurposes");

            return AndroidObjectMapper.ConvertToSetPurpose(obj);
        }

        public ISet<string> GetDisabledPurposeIds()
        {
            var obj = CallReturningJavaObjectMethod("getDisabledPurposeIds");

            return AndroidObjectMapper.ConvertToSetString(obj);
        }

        public ISet<Vendor> GetDisabledVendors()
        {
            var obj = CallReturningJavaObjectMethod("getDisabledVendors");

            return AndroidObjectMapper.ConvertToSetVendor(obj);
        }

        public ISet<string> GetDisabledVendorIds()
        {
            var obj = CallReturningJavaObjectMethod("getDisabledVendorIds");

            return AndroidObjectMapper.ConvertToSetString(obj);
        }

        public ISet<Purpose> GetEnabledPurposes()
        {
            var obj = CallReturningJavaObjectMethod("getEnabledPurposes");

            return AndroidObjectMapper.ConvertToSetPurpose(obj);
        }

        public ISet<string> GetEnabledPurposeIds()
        {
            var obj = CallReturningJavaObjectMethod("getEnabledPurposeIds");

            return AndroidObjectMapper.ConvertToSetString(obj);
        }

        public ISet<Vendor> GetEnabledVendors()
        {
            var obj = CallReturningJavaObjectMethod("getEnabledVendors");

            return AndroidObjectMapper.ConvertToSetVendor(obj);
        }

        public ISet<string> GetEnabledVendorIds()
        {
            var obj = CallReturningJavaObjectMethod("getEnabledVendorIds");

            return AndroidObjectMapper.ConvertToSetString(obj);
        }

        public string GetJavaScriptForWebView()
        {
            return CallReturningStringMethod("getJavaScriptForWebView");
        }

        public Purpose GetPurpose(string purposeId)
        {
            var obj = CallReturningJavaObjectMethod("getPurpose", purposeId);

            return AndroidObjectMapper.ConvertToPurpose(obj);
        }

        public ISet<Purpose> GetRequiredPurposes()
        {
            var obj = CallReturningJavaObjectMethod("getRequiredPurposes");

            return AndroidObjectMapper.ConvertToSetPurpose(obj);
        }

        public ISet<string> GetRequiredPurposeIds()
        {
            var obj = CallReturningJavaObjectMethod("getRequiredPurposeIds");

            return AndroidObjectMapper.ConvertToSetString(obj);
        }

        public ISet<Vendor> GetRequiredVendors()
        {
            var obj = CallReturningJavaObjectMethod("getRequiredVendors");

            return AndroidObjectMapper.ConvertToSetVendor(obj);
        }

        public ISet<string> GetRequiredVendorIds()
        {
            var obj = CallReturningJavaObjectMethod("getRequiredVendorIds");

            return AndroidObjectMapper.ConvertToSetString(obj);
        }

        public IDictionary<string, string> GetText(string key)
        {
            var obj = CallReturningJavaObjectMethod("getText", key);

            return AndroidObjectMapper.ConvertToDictionary(obj);
        }

        public string GetTranslatedText(string key)
        {
            return CallReturningStringMethod("getTranslatedText", key);
        }

        public bool GetUserConsentStatusForPurpose(string purposeId)
        {
            var boolObject = CallReturningJavaObjectMethod("getUserConsentStatusForPurpose", purposeId);

            return AndroidObjectMapper.ConvertToBoolean(boolObject);
        }

        public bool GetUserConsentStatusForVendor(string vendorId)
        {
            var boolObject = CallReturningJavaObjectMethod("getUserConsentStatusForVendor", vendorId);

            return AndroidObjectMapper.ConvertToBoolean(boolObject);
        }

        public bool GetUserConsentStatusForVendorAndRequiredPurposes(string vendorId)
        {
            var boolObject = CallReturningJavaObjectMethod("getUserConsentStatusForVendorAndRequiredPurposes", vendorId);

            return AndroidObjectMapper.ConvertToBoolean(boolObject);
        }

        public bool GetUserLegitimateInterestStatusForPurpose(string purposeId)
        {
            var boolObject = CallReturningJavaObjectMethod("getUserLegitimateInterestStatusForPurpose", purposeId);

            return AndroidObjectMapper.ConvertToBoolean(boolObject);
        }

        public bool GetUserLegitimateInterestStatusForVendor(string vendorId)
        {
            var boolObject = CallReturningJavaObjectMethod("getUserLegitimateInterestStatusForVendor", vendorId);

            return AndroidObjectMapper.ConvertToBoolean(boolObject);
        }

        public bool GetUserLegitimateInterestStatusForVendorAndRequiredPurposes(string vendorId)
        {
            return CallReturningBoolMethod("getUserLegitimateInterestStatusForVendorAndRequiredPurposes", vendorId);
        }

        public Vendor GetVendor(string vendorId)
        {
            var obj = CallReturningJavaObjectMethod("getVendor", vendorId);

            return AndroidObjectMapper.ConvertToVendor(obj);
        }

        public void HideNotice()
        {
            CallVoidMethod("hideNotice");
        }

        public void HidePreferences()
        {
            CallVoidMethod("hidePreferences");
        }

        public void Initialize(
            string apiKey,
            string localConfigurationPath,
            string remoteConfigurationURL,
            string providerId,
            bool disableDidomiRemoteConfig,
            string languageCode)
        {
            object[] args = new object[6];
            args[0] = apiKey;
            args[1] = localConfigurationPath;
            args[2] = remoteConfigurationURL;
            args[3] = providerId;
            args[4] = new AndroidJavaObject("java.lang.Boolean", disableDidomiRemoteConfig.ToString());
            args[5] = languageCode;

            CallVoidMethodForInitialize(
                "initialize",
                args);
        }

        public void Initialize(
            string apiKey,
            string localConfigurationPath,
            string remoteConfigurationURL,
            string providerId,
            bool disableDidomiRemoteConfig,
            string languageCode,
            string noticeId)
        {
            object[] args = new object[7];
            args[0] = apiKey;
            args[1] = localConfigurationPath;
            args[2] = remoteConfigurationURL;
            args[3] = providerId;
            args[4] = new AndroidJavaObject("java.lang.Boolean", disableDidomiRemoteConfig.ToString());
            args[5] = languageCode;
            args[6] = noticeId;

            CallVoidMethodForInitialize(
                "initialize",
                args);
        }

        public bool IsConsentRequired()
        {
            return CallReturningBoolMethod("isConsentRequired");
        }

        public bool IsUserConsentStatusPartial()
        {
            return CallReturningBoolMethod("isUserConsentStatusPartial");
        }

        public bool IsNoticeVisible()
        {
            return CallReturningBoolMethod("isNoticeVisible");
        }

        public bool IsPreferencesVisible()
        {
            return CallReturningBoolMethod("isPreferencesVisible");
        }

        public bool IsReady()
        {
            return CallReturningBoolMethod("isReady");
        }

        public void OnError(Action action)
        {
            var didomiCallable = new DidomiCallable(action);

            CallVoidMethod("onError", didomiCallable);
        }

        public void OnReady(Action action)
        {
            var didomiCallable = new DidomiCallable(action);

            CallVoidMethod("onReady", didomiCallable);
        }

        public void SetupUI()
        {
            CallVoidMethodWithActivityArg("setupUI");
        }

        public void ShowNotice()
        {
            CallVoidMethodWithActivityArg("showNotice");
        }

        public void ShowPreferences()
        {
            CallVoidMethodWithActivityArg("showPreferences");
        }

        public void Reset()
        {
            CallVoidMethod("reset");
        }

        public bool SetUserAgreeToAll()
        {
            return CallReturningBoolMethod("setUserAgreeToAll");
        }

        [ObsoleteAttribute("This method is deprecated. Use SetUserStatus instead.")]
        public bool SetUserConsentStatus(
            ISet<string> enabledPurposeIds,
            ISet<string> disabledPurposeIds,
            ISet<string> enabledVendorIds,
            ISet<string> disabledVendorIds)
        {
            return CallReturningBoolMethod(
                "setUserConsentStatus",
                AndroidObjectMapper.ConvertFromHasSetStringToSetAndroidJavaObject(enabledPurposeIds),
                AndroidObjectMapper.ConvertFromHasSetStringToSetAndroidJavaObject(disabledPurposeIds),
				AndroidObjectMapper.ConvertFromHasSetStringToSetAndroidJavaObject(new HashSet<string>()),
                AndroidObjectMapper.ConvertFromHasSetStringToSetAndroidJavaObject(new HashSet<string>()),
                AndroidObjectMapper.ConvertFromHasSetStringToSetAndroidJavaObject(enabledVendorIds),
                AndroidObjectMapper.ConvertFromHasSetStringToSetAndroidJavaObject(disabledVendorIds),
				AndroidObjectMapper.ConvertFromHasSetStringToSetAndroidJavaObject(new HashSet<string>()),
                AndroidObjectMapper.ConvertFromHasSetStringToSetAndroidJavaObject(new HashSet<string>()));
        }
   
        public bool SetUserStatus(
            ISet<string> enabledConsentPurposeIds,
            ISet<string> disabledConsentPurposeIds,
            ISet<string> enabledLIPurposeIds,
            ISet<string> disabledLIPurposeIds,
            ISet<string> enabledConsentVendorIds,
            ISet<string> disabledConsentVendorIds,
            ISet<string> enabledLIVendorIds,
            ISet<string> disabledLIVendorIds)
        {
            return CallReturningBoolMethod(
                "setUserStatus",
                AndroidObjectMapper.ConvertFromHasSetStringToSetAndroidJavaObject(enabledConsentPurposeIds),
                AndroidObjectMapper.ConvertFromHasSetStringToSetAndroidJavaObject(disabledConsentPurposeIds),
                AndroidObjectMapper.ConvertFromHasSetStringToSetAndroidJavaObject(enabledLIPurposeIds),
                AndroidObjectMapper.ConvertFromHasSetStringToSetAndroidJavaObject(disabledLIPurposeIds),
                AndroidObjectMapper.ConvertFromHasSetStringToSetAndroidJavaObject(enabledConsentVendorIds),
                AndroidObjectMapper.ConvertFromHasSetStringToSetAndroidJavaObject(disabledConsentVendorIds),
                AndroidObjectMapper.ConvertFromHasSetStringToSetAndroidJavaObject(enabledLIVendorIds),
                AndroidObjectMapper.ConvertFromHasSetStringToSetAndroidJavaObject(disabledLIVendorIds));
        }

        public bool SetUserStatus(
            bool purposesConsentStatus,
            bool purposesLIStatus,
            bool vendorsConsentStatus,
            bool vendorsLIStatus)
        {
            return CallReturningBoolMethod(
                "setUserStatus",
                purposesConsentStatus,
                purposesLIStatus,
                vendorsConsentStatus,
                vendorsLIStatus);
        }

        public bool SetUserDisagreeToAll()
        {
            return CallReturningBoolMethod("setUserDisagreeToAll");
        }

        public bool ShouldConsentBeCollected()
        {
            return CallReturningBoolMethod("shouldConsentBeCollected");
        }

        public void UpdateSelectedLanguage(string languageCode)
        {
            CallVoidMethod("updateSelectedLanguage", languageCode);
        }

        private static bool CallReturningBoolMethod(string methodName, params object[] args)
        {
            return CallReturningMethodBase<bool>(methodName, args);
        }

        private static string CallReturningStringMethod(string methodName, params object[] args)
        {
            return CallReturningMethodBase<string>(methodName, args);
        }

        private static AndroidJavaObject CallReturningJavaObjectMethod(string methodName, params object[] args)
        {
            return CallReturningMethodBase<AndroidJavaObject>(methodName, args);
        }

        private static void CallVoidMethodWithActivityArg(string methodName)
        {
            try
            {
                using (var playerClass = new AndroidJavaClass(UnityPlayerFullClassName))
                {
                    using (var activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity"))
                    {
                        using (var _pluginClass = new AndroidJavaClass(PluginName))
                        {
                            var pluginInstance = _pluginClass.CallStatic<AndroidJavaObject>("getInstance");

                            pluginInstance.Call(methodName, activity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Log(string.Format("Exception:{0}", ex.ToString()));

                throw ex;
            }
        }

        private static void CallReturningMethodWithActivityArg(string methodName)
        {
            try
            {
                using (var playerClass = new AndroidJavaClass(UnityPlayerFullClassName))
                {
                    using (var activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity"))
                    {
                        using (var _pluginClass = new AndroidJavaClass(PluginName))
                        {
                            var pluginInstance = _pluginClass.CallStatic<AndroidJavaObject>("getInstance");

                            pluginInstance.Call<AndroidJavaObject>(methodName, activity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Log(string.Format("Exception:{0}", ex.ToString()));

                throw ex;
            }
        }

        private static void CallVoidMethodForInitialize(string methodName, object[] args)
        {
            try
            {
                using (var playerClass = new AndroidJavaClass(UnityPlayerFullClassName))
                {
                    using (var activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity"))
                    {
                        using (var _pluginClass = new AndroidJavaClass(PluginName))
                        {
                            var application = activity.Call<AndroidJavaObject>("getApplication");
                            
                            var pluginInstance = _pluginClass.CallStatic<AndroidJavaObject>("getInstance");

                            MapNullValuesToJava(args);

                            var obj = new object[args.Length + 1];

                            for (int i = 1; i < obj.Length; i++)
                            {
                                obj[i] = args[i - 1];
                            }

                            obj[0] = application;
                            pluginInstance.Call(methodName, obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Log(string.Format("Exception:{0}", ex.ToString()));

                throw ex;
            }
        }

        private static void CallVoidMethod(string methodName, params object[] args)
        {
            try
            {
                using (var _pluginClass = new AndroidJavaClass(PluginName))
                {
                    var pluginInstance = _pluginClass.CallStatic<AndroidJavaObject>("getInstance");

                    MapNullValuesToJava(args);

                    pluginInstance.Call(methodName, args);
                }
            }
            catch (Exception ex)
            {
                Debug.Log(string.Format("Exception:{0}", ex.ToString()));

                throw ex;
            }
        }

        private static T CallReturningMethodBase<T>(string methodName, params object[] args)
        {
            T retval = default(T);

            try
            {
                using (var _pluginClass = new AndroidJavaClass(PluginName))
                {
                    var pluginInstance = _pluginClass.CallStatic<AndroidJavaObject>("getInstance");

                    MapNullValuesToJava(args);

                    retval = pluginInstance.Call<T>(methodName, args);
                }
            }
            catch (Exception ex)
            {
                Debug.Log(string.Format("Exception:{0}", ex.ToString()));

                throw ex;
            }

            return retval;
        }

        /// <summary>
        /// Android libraries in Unity cannot handle C# null values and throw a MethodNotFound exception
        /// when null is provided. This function maps null values to avoid that issue..
        /// </summary>
        /// <param name="args"></param>
        private static void MapNullValuesToJava(object[] args)
        {
            AndroidJavaObject nullObject = null;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == null)
                {
                    args[i] = nullObject;
                }
            }
        }
    }
}
