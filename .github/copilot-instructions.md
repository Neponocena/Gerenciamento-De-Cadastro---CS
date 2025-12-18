# Copilot / AI Agent Instructions for PIM2.0

**Purpose:** Short, actionable guidance to help an AI coding assistant be productive in this C# console project.

- **Project type:** : .NET console app targeting `net10.0` ([PIM2.0.csproj](PIM2.0.csproj)). Build/run with `dotnet build` / `dotnet run` from the repository root.
- **Entry point:** `Program.Main` in [Program.cs](Program.cs#L1). Note: `Menu.Mostrar()` is currently commented out; enabling the interactive menu requires calling it from `Main` or running the compiled exe.

- **Data storage:** Simple text files in the repo root. Primary file: `alunos.txt` (created/updated at runtime). The format is semicolon-separated: `Matricula;Nome;Turma` (see [AlunoMatriculas.cs](AlunoMatriculas.cs#L1-L40)). Example line: `123;João Silva;B1`.

- **Key modules & patterns:**
  - **`Arquivo`** ([Arquivotxt.cs](Arquivotxt.cs#L1-L60)) — low-level file I/O helpers: `SalvarLista`/`CarregarLista`. Uses relative paths; working directory matters.
  - **`Alunos`** (static) ([Cadastro.cs](Cadastro.cs#L1-L200)) — in-memory list `alunos` loaded at startup via `Carregar()` and persisted with `Salvar()`. Uses `CAMINHO = "alunos.txt"` constant. Many flows call `Menu.Mostrar()` after actions.
  - **`Aluno`** (model) ([AlunoMatriculas.cs](AlunoMatriculas.cs#L1-L60)) — simple POCO with `ToString()` and `FromString(string)` to convert to/from the semicolon format.
  - **`Menu`** ([Menu.cs](Menu.cs#L1-L200)) — console UI and lightweight control flow; it uses `Console.ReadLine()` and recursion to re-show the menu.

- **Error handling & UX conventions:**
  - Console-first, synchronous flows. Uses `Console.ReadKey()` to pause and `Menu.Mostrar()` to return to menu.
  - `Menu.Mostrar()` wraps logic in a broad `try/catch` and prints a generic error message; avoid assuming granular exceptions are already handled.

- **Typical change areas & quick examples:**
  - To add a new student attribute: update `Aluno` class, update `ToString()`/`FromString()` and update `Cadastro.Cadastrar()` and `Alunos.Salvar()` call sites.
  - To change persistence (e.g., move to JSON): replace `Arquivo.SalvarLista` / `CarregarLista` implementations and adjust `Aluno.ToString()`/`FromString()` usages or centralize conversion logic.
  - To add functionality for changing a student's class: implement `MudarAlunoTurma.cs` — the file exists but is empty; follow `Alunos` patterns for loading/saving.

- **Build & run commands:**
  - Build: `dotnet build` (from repo root).
  - Run (interactive): `dotnet run` (from repo root) or open the project in Visual Studio and run the console app.
  - Runtime requirement: .NET 10 SDK to match `TargetFramework`.

- **Developer notes for agents:**
  - Prefer editing `Alunos` static APIs (e.g., add helper methods) rather than scattering file I/O logic around.
  - Keep the `CAMINHO` constant in `Alunos` as single source of truth for the data file path.
  - When modifying data format, update `Aluno.FromString` and `Aluno.ToString` together and run local manual scenarios (create sample `alunos.txt`) to validate.
  - Use relative file paths cautiously: CI or test runners may have different working directories.

- **Files to inspect when troubleshooting:**
  - [Cadastro.cs](Cadastro.cs#L1-L200) — main CRUD flows.
  - [Arquivotxt.cs](Arquivotxt.cs#L1-L120) — persistence helpers.
  - [AlunoMatriculas.cs](AlunoMatriculas.cs#L1-L60) — data model conversions.
  - [Menu.cs](Menu.cs#L1-L200) — CLI control flow and UX patterns.

If any section is unclear or you want more examples (e.g., patch to switch to JSON or unit-test scaffold), tell me which area to expand or change.
