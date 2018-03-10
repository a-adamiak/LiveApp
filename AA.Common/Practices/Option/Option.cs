using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AAS.Common.Practices.Option.Core;
using AAS.Common.Practices.Option.Implementation;
using NullGuard;

namespace AAS.Common.Practices.Option
{
	public class Option<TContent> : IEnumerable<TContent>
	{
		public static implicit operator Option<TContent>([AllowNull] TContent value)
		{
			return Some(value);
		}

		private Option(IEnumerable<TContent> content)
		{
			Content = content;
		}

		public bool HasValue => Content.Any();
		public bool IsEmpty => !HasValue;

		private IEnumerable<TContent> Content { get; }
		public TContent Value => Content.FirstOrDefault();

		public static Option<TContent> None => new Option<TContent>(Array.Empty<TContent>());

		public IEnumerator<TContent> GetEnumerator()
		{
			return Content.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public static Option<TContent> Some(TContent value)
		{
			if (!typeof(TContent).IsValueType && value == null)
				return None;
			return new Option<TContent>(new[] {value});
		}


		public IFiltered<TContent> When(Func<TContent, bool> predicate)
		{
			return
				Content
					.Select(item => WhenSome(item, predicate))
					.DefaultIfEmpty(new NoneNotMatchedAsSome<TContent>())
					.Single();
		}

		private IFiltered<TContent> WhenSome(TContent value, Func<TContent, bool> predicate)
		{
			return predicate(value)
				? new SomeMatched<TContent>(value)
				: (IFiltered<TContent>) new SomeNotMatched<TContent>(value);
		}

		public IFiltered<TContent> WhenSome()
		{
			return
				Content
					.Select<TContent, IFiltered<TContent>>(item => new SomeMatched<TContent>(item))
					.DefaultIfEmpty(new NoneNotMatchedAsSome<TContent>())
					.Single();
		}

		public IFilteredNone<TContent> WhenNone()
		{
			return
				Content
					.Select<TContent, IFilteredNone<TContent>>(item => new SomeNotMatchedAsNone<TContent>(item))
					.DefaultIfEmpty(new NoneMatched<TContent>())
					.Single();
		}
	}
}