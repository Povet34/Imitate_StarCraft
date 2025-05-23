using RTS.Units;
using UnityEngine;

namespace RTS.Commands
{
    public interface ICommand
    {
        bool CanHandle(CommandContext context);
        void Handle(CommandContext context);
    }
}
