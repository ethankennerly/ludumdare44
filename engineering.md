# Profile

- [Performance profile](performance_profile.md)

# Words

## Find words with exact length

Example: 3 letter max length:

        grep " word: [a-z]\{3\}$" Level_*.asset
        Level_1.asset:  word: and
        Level_10.asset:  word: rod
        Level_11.asset:  word: pat
        Level_2.asset:  word: for
        Level_3.asset:  word: say
        Level_4.asset:  word: but
        Level_5.asset:  word: fog
        Level_6.asset:  word: low
        Level_7.asset:  word: opt
        Level_8.asset:  word: arm
        Level_9.asset:  word: ash

## Find longest answers

Longest answers is 7 letters.
To find levels with this length,
In Word Link Resources directory at the command line, search:

        grep "|[a-z]\{7\}|" Level_*.asset

Examples:

        Level_354.asset:  answers: music|claim|musical|

        Level_710.asset:  validWords: viper|pearl|paler|peril|velar|viler|liver|rival|viral|alive|prevail|
