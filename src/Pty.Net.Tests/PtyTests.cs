﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Pty.Net.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class PtyTests
    {
        [Fact]
        public async Task ConnectToTerminal()
        {
            const string Data = "abc✓ЖЖЖ①Ⅻㄨㄩ 啊阿鼾齄丂丄狚狛狜狝﨨﨩ˊˋ˙– ⿻〇㐀㐁䶴䶵";

            using var terminal = await Utilities.CreateConnectionAsync(Utilities.TimeoutToken);

            await terminal.RunCommand($"echo {Data}", Utilities.TimeoutToken);

            Assert.True(await Utilities.FindOutput(terminal.ReaderStream, Data));
        }

        [Fact]
        public async Task OldConnectToTerminal()
        {
            const string Data = "abc✓ЖЖЖ①Ⅻㄨㄩ 啊阿鼾齄丂丄狚狛狜狝﨨﨩ˊˋ˙– ⿻〇㐀㐁䶴䶵";

            using var terminal = await Utilities.CreateConnectionAsync(Utilities.TimeoutToken);

            var output = await Utilities.RunAndFind(terminal, $"echo {Data}", Data, Utilities.TimeoutToken);

            Assert.NotNull(output);
        }
    }
}
