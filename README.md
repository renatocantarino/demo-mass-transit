# demo-mass-transit
app using massTransit , .NET CORE

------------------------------------------
docker run -d — hostname my-rabbit — name rabbit13 -p 8080:15672 -p 5672:5672 -p 25676:25676 rabbitmq:3-management
------------------------------------------
massTransit

-> framework open
-> ajudar a rotear mensagem/evento para os serviços de mesageria (rabitt, kafa, azure service bus, sqs, ActiveMq)
-> ajuda a criar a e potencializar a comunicação assincrona
-> abstração de um barramento de mensagem(bus)



1. transpot

-> Rabit
-> AZB
-> SQS
_> InMemory


-> Concorrencia

- Inscrito com a TPL
- Gerenciamento da conexao(retry pattern).
- Tratamento de excessao
- releituras de mensagem
- mensagem suspeitas
- Gerenciamento do ciclo de vida do consumer
- Agendametno


-> Mensagem

-> fortemente tipadas
-> devem ser anemicas 
-> readOnly properties
-> eventos : notifica um acontecimento
    -> via publish por meio do IBus(standonle)
    -> o evento nao pode ser enviado diretamento para o endpoint do consumer

-> Command: faça algo
   -> via send
   -> direto para o endpoint


Consumidors

-> consome 1 ou mais tipos de msgs, desde q configurado e conectado ao endpoito

IConsumer<I>

Tipo

-> Sagas,
-> Maquina de estado de sagas
-> atv de roteamento
-> Jobs

Producer

-> enviado  -> direto a um endpoint (destinationAdress)
-> publicada -> transmitida a um consumidor especifico que esta esperando
