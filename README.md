@::::::::::::::::::::::::::::::::::::::::::::::::::@
|                                                  |
| Pokémon Generation 5 Save tool by suloku '16-21  |
|                                                  |
@::::::::::::::::::::::::::::::::::::::::::::::::::@

Source code is available here: https://github.com/suloku/BW_tool

This is a multipurpose savegame editor for generation 5 games.

Current features:
_________________

For BW and BW2:

* Entralink forest editor (*see exanded note)
* Trainer information and badges editor (also rival name for BW2)
* Prop Case editor
* Block dumper/injector (also decripts/recripts the known encrypted blocks such as entralink forest data block)
* Checksum verifier/corrector

Only for BW2:

* Hidden grotto and swarm editor
* Join Avenue editor (also can import/export visitors)**
* Key system editor (allows to unlock any keys and change the game configuration)
* Medal editor: still in a very basic stage, but allows to unlock any medal (to unlock a medal, set it to any date).
* Memory Link editor: can edit trainer name, TID and SID. Can export/import the memory link block. Can import Name, TID, SID and hall of fame from BW1 savegame. The flags are mostly unknown for now.
* 3DS Link editor: this allows to edit the 3DS link data, which was only ever used by Pokémon Dream radar. This has a "legal mode" (default), on which you can only insert pokémon and items available in Dream Radar and a "All mode" on which you can insert any pokémon or item. The main purpose is to allow the retreival of Dream Radar exclusive pokémon (like weather trio terrian formes) without the actual need to use Dream Radar. You can also clear the catched flags so you may transfer the legendary pokémon again to your savefile.

**4 visitor files are included in the file


*About entralink forest editor:

Two kind of files can be used: phl files, which are AREA files and are compatible with pockestock and pikaedit; and efdd files, which is basically the decrypted forest block, so it contains all areas and forest settings. The package includes a legitimate efdd file from Black 1 containing several Dream World Pokémon and the PGL Arceus; and also a legitimate efdd file from White 2 with a couple event pokemon and 9 dream world Pokémon.

The most interesting feature is the "Dream World Simulator", which are some handy buttons with the Dream World areas that allow injecting to the forest a pokémon from Dream World. The pokémon are restricted to what the dream world offered and only that. Each pokémon allows to select the move slot A, B or C*** and gender when aplicable (remember that in gen 5 only females can produce hidden ability eggs).

Similar to "Dream World Simulator" there's a PGL Promotions button, that allows to inject the PGL distributed pokémon as they were distributed. Please note that some of these pokémon were only obtainable on some languages, so receiving it in another language game renders it ilegal. The languages the pokémon could be received on are shown on screen for convenience. Also, these pokémon had fixed gender and moves.

Just to clarify: any pokémon injected using the Dream World or PGL buttons will be absolutely the same as if received from the online service (except out of region PGL pokémon, as there is no region filter in the editor).


*** Dream World moves
A: the pokémon learns via level up
B: pokemon learns trough breeding
C: dream world exclusive move or breeding move (depends on the pokemon)


Possible future features:
_________________

* Finish medal editor and trainer records: these features need research, since some medals are tied to in-game records. The goal is to make the editing as legit as possible, at the very least for the online exclusive medals that are not obtainable anymore and those almost impossible to obtain medals (30 people funfest mission, etc.).
* Memory link injecting/editing for BW2, and maybe importing some data from a BW1 savegame to memory link.


Note: there's a trainer records button, which is a possible future feature, and I haven't locked it for release.
Note 2: savegame can be loaded via drag and drop.


Thanks to:
__________

Many people that I'm probably missing out now, but those who shall not be missed are BlackShark for many research and information and kaphotics for reference on pkhex source code and research at project pokemon forums.