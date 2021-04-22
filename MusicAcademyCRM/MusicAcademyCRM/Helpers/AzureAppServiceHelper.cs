﻿#define OFFLINE_SYNC_ENABLED



using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using MusicAcademyCRM.Model;

namespace MusicAcademyCRM.Helpers
{
    public class AzureAppServiceHelper
    {
        public static async Task SyncAsync()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                await App.MobileService.SyncContext.PushAsync();

               

            }
            catch (MobileServicePushFailedException mspfe)
            {
                if (mspfe.PushResult != null)
                    syncErrors = mspfe.PushResult.Errors;
            }
            catch (Exception ex)
            {
                

            }

            if (syncErrors != null)
            {
                foreach (var error in syncErrors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else
                    {
                        await error.CancelAndDiscardItemAsync();
                    }
                }
            }
        }
    }
}
