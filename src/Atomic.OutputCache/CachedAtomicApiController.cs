using Atomic.Api;
using Microsoft.AspNetCore.OutputCaching;

namespace Atomic.OutputCache;

[OutputCache(PolicyName = Constants.AtomicPolicyName)]
public class CachedAtomicApiController : AtomicApiController
{ }