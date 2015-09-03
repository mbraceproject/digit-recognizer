﻿#I "../../packages/MBrace.Azure/tools" 
#load "../../packages/MBrace.Azure/MBrace.Azure.fsx"

namespace global

[<AutoOpen>]
module ConnectionStrings = 

    open MBrace.Core
    open MBrace.Azure

    // Both of the connection strings can be found under "Cloud Service" --> "Configure" --> scroll down to "MBraceWorkerRole"
    //
    // The storage connection string is of the form  
    //    DefaultEndpointsProtocol=https;AccountName=myAccount;AccountKey=myKey 
    //
    // The serice bus connection string is of the form
    //    Endpoint=sb://%s.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=%s

    let myStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=myAccount;AccountKey=myKey"
    let myServiceBusConnectionString = "Endpoint=sb://%s.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=%s"

    // Alternatively you can specify the connection strings by calling the functions below
    //
    // storageName: the one you specified when you created cluster.
    // storageAccessKey: found under "Manage Access Keys" for that storage account in the Azure portal.
    // serviceBusName: the one you specified when you created cluster.
    // serviceBusKey: found under "Configure" for the service bus in the Azure portal
    
    let createStorageConnectionString(storageName, storageAccessKey) = sprintf "DefaultEndpointsProtocol=https;AccountName=%s;AccountKey=%s" storageName storageAccessKey
    let createServiceBusConnectionString(serviceBusName, serviceBusKey) = sprintf "Endpoint=sb://%s.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=%s" serviceBusName serviceBusKey

    let config = new Configuration(myStorageConnectionString, myServiceBusConnectionString)