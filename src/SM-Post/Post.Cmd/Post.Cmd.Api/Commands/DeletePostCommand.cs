using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
	public class DeletePostCommand : BaseCommand
	{
		public string Username { get; set; }
	}
}