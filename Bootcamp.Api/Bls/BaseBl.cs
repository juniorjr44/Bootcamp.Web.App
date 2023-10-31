using System.Text.Json;
using System;

namespace Bootcamp.Api.Bls
{
    public abstract class BaseBl
    {
        protected async Task<string> ReadData() => await File.ReadAllTextAsync(@"./Data/Contact.json");
    }
}
