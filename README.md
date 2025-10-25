# Junk-Importer
.NET Obfuscation Protection

**Junk-Importer** is a modular .NET obfuscation engine designed to inject high-entropy junk logic into assemblies using `dnlib`. It targets reverse engineering resistance by flooding real types with randomized, meaningless methods that look advanced but do nothing — perfect for confusing decompilers and static analysis tools.

---

## Features

- Injects junk methods into **real types** and **randomized junk types**
- Supports:
  - Parameterless junk methods
  - Return-type junk methods
  - Complex-looking methods with parameters
- Randomizes method and type names for maximum entropy
- Skips compiler-generated lambdas to ensure dnlib compatibility
- Fully compatible with Unity, BepInEx, and plugin environments

---

## Usage

```bash
JunkImporter.exe <path-to-assembly>
