﻿/*
 * Markdown File Handler - Sample Code
 * Copyright (c) Microsoft Corporation
 * All rights reserved. 
 * 
 * MIT License
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of 
 * this software and associated documentation files (the ""Software""), to deal in 
 * the Software without restriction, including without limitation the rights to use, 
 * copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the
 * Software, and to permit persons to whom the Software is furnished to do so, 
 * subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all 
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
 * PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION 
 * OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

namespace MarkdownFileHandler.Utils
{
    using System;
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;

    public class AzureTableContext
    {
        private CloudStorageAccount StorageAccount
        {
            get { return CloudStorageAccount.Parse(@"DefaultEndpointsProtocol=https;AccountName=storageaccountbksp8694;AccountKey=E/6gvRgcex4gUuX0foiEom84wRsB+t9CKOt0xjXV1sZJ+r3If0q/45vb0RimSS5sEX04sot0trVUl8YcHwQUaw==;BlobEndpoint=https://storageaccountbksp8694.blob.core.windows.net/;TableEndpoint=https://storageaccountbksp8694.table.core.windows.net/;QueueEndpoint=https://storageaccountbksp8694.queue.core.windows.net/;FileEndpoint=https://storageaccountbksp8694.file.core.windows.net/"); }

        }

        private readonly CloudTableClient client;

        public readonly CloudTable UserTokenCacheTable;
        

        public AzureTableContext()
        {
            client = this.StorageAccount.CreateCloudTableClient();
            UserTokenCacheTable = client.GetTableReference("tokenCache");
            UserTokenCacheTable.CreateIfNotExists();
        }
    }


    public class TokenCacheEntity : TableEntity
    {
        public const string PartitionKeyValue = "tokenCache";
        public TokenCacheEntity()
        {
            this.PartitionKey = PartitionKeyValue;
        }

        public byte[] CacheBits { get; set; }
        public DateTime LastWrite { get; set; }
    }
    
}