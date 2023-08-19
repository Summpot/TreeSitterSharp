project('tree-sitter-lua', 'c')

incdir = include_directories('src/src')

shared_library('tree-sitter-lua',
            sources : ['src/src/parser.c', 'src/src/scanner.c'], 
            include_directories : incdir)