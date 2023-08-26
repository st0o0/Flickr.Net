#!/usr/bin/env bash
# Copyright (c) .NET Foundation and contributors. All rights reserved.
# Licensed under the MIT license. See LICENSE file in the project root for full license information.
#

# Stop script on NZEC
set -e

wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh

chmod +x ./dotnet-install.sh

./dotnet-install.sh --channel 8.0 --install-dir /usr/local/dotnet/current