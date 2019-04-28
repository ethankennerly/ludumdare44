# Copied from: https://stackoverflow.com/a/27117480/1417849
def removeUnityTagAlias(filepath):
    """
    Name:               removeUnityTagAlias()

    Description:        Loads a file object from a Unity textual scene file, which is in a pseudo YAML style, and strips the
                        parts that are not YAML 1.1 compliant. Then returns a string as a stream, which can be passed to PyYAML.
                        Essentially removes the "!u!" tag directive, class type and the "&" file ID directive. PyYAML seems to handle
                        rest just fine after that.

    Returns:                String (YAML stream as string)  


    """
    result = str()
    sourceFile = open(filepath, 'r')

    for lineNumber,line in enumerate( sourceFile.readlines() ): 
        if line.startswith('--- !u!'):          
            result += '--- ' + line.split(' ')[2] + '\n'   # remove the tag, but keep file ID
        else:
            # Just copy the contents...
            result += line

    sourceFile.close()  

    return result
