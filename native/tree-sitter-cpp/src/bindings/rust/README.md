# tree-sitter-cpp

This crate provides a CPP grammar for the [tree-sitter][] parsing library. To
use this crate, add it to the `[dependencies]` section of your `Cargo.toml`
file. (Note that you will probably also need to depend on the
[`tree-sitter`][tree-sitter crate] crate to use the parsed result in any useful
way.)

```toml
[dependencies]
tree-sitter = "0.20.10"
tree-sitter-cpp = "0.20.3"
```

Typically, you will use the [language][language] function to add this
grammar to a tree-sitter [Parser][], and then use the parser to parse some code:

```rust
let code = r#"
    int double(int x) {
        return x * 2;
    }
"#;
let mut parser = Parser::new();
parser.set_language(tree_sitter_cpp::language()).expect("Error loading CPP grammar");
let parsed = parser.parse(code, None);
```

If you have any questions, please reach out to us in the [tree-sitter
discussions] page.

[language]: https://docs.rs/tree-sitter-cpp/*/tree_sitter_cpp/fn.language.html
[Parser]: https://docs.rs/tree-sitter/*/tree_sitter/struct.Parser.html
[tree-sitter]: https://tree-sitter.github.io/
[tree-sitter crate]: https://crates.io/crates/tree-sitter
[tree-sitter discussions]: https://github.com/tree-sitter/tree-sitter/discussions
