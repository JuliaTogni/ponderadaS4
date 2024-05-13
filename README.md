# Ponderada Semana 4

## Monitoramento de Métricas com .NET

Este projeto demonstra a implementação de monitoramento de métricas em uma aplicação .NET, seguindo as práticas recomendadas e utilizando a biblioteca `System.Diagnostics.Metrics`. O código baseia-se em um tutorial detalhado disponível na [documentação oficial do .NET](https://learn.microsoft.com/pt-br/dotnet/core/diagnostics/metrics-instrumentation), que fornece uma visão abrangente sobre como instrumentar aplicações .NET para coletar e visualizar métricas de desempenho em tempo real.

## Conceitos Aprendidos

Durante o desenvolvimento deste projeto, vários conceitos fundamentais foram explorados e implementados:

- **Métricas e Medidores (`Meter`)**: Aprendi como criar e utilizar medidores para definir métricas customizadas dentro de uma aplicação.
- **Contadores (`Counter`)**: Utilizei contadores para acompanhar quantidades incrementais, como o número de vendas ou transações.
- **Histogramas (`Histogram`)**: Implementei histogramas para capturar a distribuição de valores medidos, como o tempo de processamento de pedidos.
- **Gauges Observáveis (`ObservableGauge`)**: Explorei através do tutorial como usar gauges observáveis para monitorar valores que variam com o tempo, como pedidos pendentes.
- **`MeterListener`**: Configurei ouvintes para responder a eventos de métricas e coletar dados em tempo real.
- **Manipulação de Métricas em Tempo Real**: Desenvolvemos um esquema, seguindo o tutorial, para exibir e atualizar métricas em tempo real no console, permitindo interações através do terminal para pausar e retomar a coleta de métricas.

### Evidência 1
<img src='./assets/Captura de tela 2024-05-12 212603.png'/>

### Evidência 2
<img src='./assets/Captura de tela 2024-05-13 011214.png'/>

### Evidência 3
<img src='./assets/Captura de tela 2024-05-13 011429.png'/>

### Evidência 4
<img src='./assets/Captura de tela 2024-05-13 011654.png'/>

### Evidência 5
<img src='./assets/Captura de tela 2024-05-13 011846.png'/>



## Conclusão

Este projeto forneceu uma base prática para a implementação de medições de métricas, que será muito útil para o projeto que estamos desenvolvendo atualmente. Este conhecimento será aplicado para aprimorar não apenas o projeto corrente, mas também projetos futuros, consolidando um ciclo de melhoria contínua em nossa abordagem de desenvolvimento de software.
