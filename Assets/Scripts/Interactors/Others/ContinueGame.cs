﻿using Arkham.Config;
using Arkham.Services;
using Zenject;

namespace Arkham.Interactors
{
    public class ContinueGame : IContinueGame
    {
        [Inject] private readonly GameFiles gameFiles;
        [Inject] private readonly IFileAdapter fileAdapter;

        /*******************************************************************/
        public bool CanContinue() => fileAdapter.FileExist(gameFiles.PlayerProgressFilePath);
    }
}
