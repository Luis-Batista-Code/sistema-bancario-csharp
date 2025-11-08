# 🏦 [Bank] - Sistema Bancário em C#

Um sistema bancário completo desenvolvido em C# e .NET, focado em demonstrar os principais conceitos de **Programação Orientada a Objetos (POO)**. Este projeto simula uma experiência bancária, oferecendo funcionalidades modernas como PIX, investimentos e **persistência de dados em JSON**.

✨ Características do Projeto

🎯 Conceitos de POO Aplicados

* 🔒 **Encapsulamento:** Proteção de dados sensíveis das contas (usando propriedades C# `{ get; set; }`).
* 🏗️ **Herança:** Classe abstrata `Conta` e implementação `ContaCorrente`.
* 🔄 **Polimorfismo:** Métodos `abstract` e `override` (como o `Sacar`).
* 📦 **Abstração:** Interface simples para operações bancárias complexas.
* ♻️ **Reutilização:** Componentes modulares e reutilizáveis.

🚀 Funcionalidades

* 💳 **Gestão de Contas**
    * ✅ Criação de contas com dados do cliente (Nome, CPF).
    * ✅ Verificação de número de conta único.
    * ✅ Controle de saldo em tempo real.
* 💰 **Operações Bancárias**
    * 📈 **Depósitos:** Adicionar valores à conta.
    * 📉 **Saques:** Retirar valores com verificação de saldo.
    * 🔄 **PIX:** Transferências instantâneas entre contas.
    * 📊 **Investimentos:** Simulação de rendimentos com juros compostos.
    * 📜 **Histórico:** Registro completo de todas as transações.
* 💾 **Persistência de Dados**
    * ✅ **Banco de Dados JSON:** O sistema **salva automaticamente** todas as contas e transações em um arquivo `contas.json`.
    * ✅ **Carregamento Automático:** Ao iniciar, o sistema carrega todos os dados salvos anteriormente, garantindo que nenhuma informação seja perdida.

🛡️ Validações e Segurança

* Verificação de saldo suficiente.
* Validação de contas existentes.
* Tratamento de entradas inválidas (usando `TryParse`) para evitar que o programa quebre.
* Registro detalhado de operações no histórico.

---

📁 Estrutura do Projeto

O projeto segue uma estrutura simplificada, ideal para aplicações de console, onde todas as classes de lógica estão na raiz do projeto.
```sh
sistema-bancario/
├── Program.cs                    # Interface do usuário e menu principal
├── model/
│   ├── Cliente.cs            # Entidade cliente (nome, CPF)
│   ├── Conta.cs              # Classe abstrata base
│   ├── ContaCorrente.cs      # Implementação de conta corrente
│   ├── Investimento.cs       # Lógica de investimentos
│   └── SistemaBancario.cs    # Gerenciamento do sistema
├── README.md
└── LICENSE
```
---

🛠️ Como Executar

**Pré-requisitos**

* 💿 **.NET SDK** (6.0 ou superior)
* 🖥️ **VS Code** (ou Visual Studio)

**Passos para execução**

1.  Clone o repositório
    ```sh
    git clone [https://github.com/](https://github.com/)[Seu GitHub]/[Seu Repositorio]
    cd [Seu Repositorio]
    ```

2.  Execute a aplicação (via terminal)
    ```sh
    dotnet run
    ```

---

🎮 Como Usar

Ao executar o programa, você verá o menu principal no seu terminal:

=== Bem-vindo ao Bank ===

Escolha uma opção:
1 - Criar conta
2 - Depositar
3 - Sacar
4 - Transferência via PIX
5 - Investir
6 - Mostrar histórico
0 - Sair

* **Exemplo de Uso:** Crie duas contas (ex: "123" e "456"). Deposite um valor na conta "123". Faça um PIX da "123" para a "456". Saia do programa (opção 0). Execute o programa novamente (`dotnet run`) e consulte o histórico de ambas as contas. Os dados estarão lá!

🔢 Exemplo de Investimento

O sistema simula investimentos usando **juros compostos**:

* **Valor investido:** R$ 1.000,00
* **Rendimento mensal:** 2% (0.02)
* **Período:** 12 meses
* **Resultado:** R$ 1.268,24 (lucro de R$ 268,24)

---

🏛️ Arquitetura

* **Padrões Utilizados:**
    * **Separação de Responsabilidades (SoC):** Cada classe tem um propósito único (`Cliente` guarda dados, `Conta` tem regras de saldo, `SistemaBancario` gerencia tudo).
    * **Repository (Simplificado):** A classe `SistemaBancario` atua como um repositório, gerenciando a coleção de contas e lidando com a **persistência (leitura/escrita) no arquivo JSON**.
* **Classes Principais:**

| Classe | Responsabilidade |
| :--- | :--- |
| **Cliente** | Dados pessoais do cliente. |
| **Conta** | Classe abstrata com operações básicas (Saldo, Histórico). |
| **ContaCorrente** | Implementação específica de conta (Saque). |
| **Investimento** | Cálculos de rendimento e juros compostos. |
| **SistemaBancario**| Gerenciamento do sistema, lógica de negócio e **persistência de dados**. |
| **Program** | Ponto de entrada (Main) e interface do usuário (menu). |

---

🎓 Conceitos Aplicados (Tecnologias da Conversão)

Este projeto aplica conceitos fundamentais de C# e do ecossistema .NET:

* **Ecossistema .NET:** Uso do `dotnet CLI` (`dotnet new`, `dotnet run`) para gerenciamento do projeto.
* **Sintaxe C#:** Migração da sintaxe Java para C#, incluindo:
    * **Propriedades:** Uso de `{ get; set; }` para encapsulamento.
    * **Namespaces:** Organização do código (`namespace SistemaBancarioApp`).
    * **Formatação de String:** Uso de `$` (string interpolation), ex: `$"Depósito: R${valor}"`.
* **Coleções C#:** Substituição de `HashMap` (Java) por `Dictionary<>` (C#) e `ArrayList` por `List<>`.
* **Persistência de Dados (O "Banco de Dados")**
    * **Serialização JSON:** Uso da biblioteca `System.Text.Json` para converter a lista de contas (`Dictionary`) em uma string JSON.
    * **Deserialização JSON:** Ler o arquivo `contas.json` e converter o texto de volta para objetos C# (`Dictionary<string, ContaCorrente>`).
    * **I/O de Arquivos:** Uso de `System.IO` (`File.ReadAllText`, `File.WriteAllText`, `File.Exists`) para ler e salvar o arquivo JSON.
* **Entrada Segura:** Uso de `int.TryParse` e `double.TryParse` para validar a entrada do usuário e prevenir erros.

---

🤝 Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para:

1.  Fazer `fork` do projeto
2.  Criar uma branch para sua feature (`git checkout -b feature/nova-funcionalidade`)
3.  Commit suas mudanças (`git commit -am 'Adiciona nova funcionalidade'`)
4.  Push para a branch (`git push origin feature/nova-funcionalidade`)
5.  Abrir um Pull Request

---

📄 Licença

Este projeto está licenciado sob a **Licença MIT** - veja o arquivo `LICENSE` para detalhes.

---

👨‍💻 Autor

* **[Luis Batista]**
* **GitHub:** `@[Luis-Batista-Code]`

⭐ *Se este projeto te ajudou, considere dar uma estrela!*
