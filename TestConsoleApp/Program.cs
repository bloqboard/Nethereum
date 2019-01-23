using System;
using System.Threading.Tasks;
using CL.General.SaiTub.CQS;
using CL.General.SaiTub.Service;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;

namespace TestConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string nodeAddress = "https://kovan.infura.io/mpuFTnpStVhztVUPWeMC";
            var web3 = new Web3(nodeAddress);

            string contractAddress = "0xa71937147b55deb8a530c7229c442fd3f31b7db2";
            var saiTubService = new SaiTubService(web3, contractAddress);

            // to make sure that we got configuration right
            var tax = await saiTubService.TaxQueryAsync();
            var fee = await saiTubService.FeeQueryAsync();

            // to make sure that approach to filter events is working (logNewCupEventLogs is not empty)
            var logNewCupEventHandler = web3.Eth.GetEvent<LogNewCupEventDTO>(contractAddress);
            var logNewCupFilter = logNewCupEventHandler.CreateFilterInput(BlockParameter.CreateEarliest(), BlockParameter.CreateLatest());
            var logNewCupEventLogs = await logNewCupEventHandler.GetAllChanges(logNewCupFilter);

            // actual anonymous event parsing -- bite function
            var methodSignature = Web3.Sha3("bite(bytes32)").Substring(0, 8);
            var methodSignatureByteArray = methodSignature.HexToByteArray();
            var logNoteEventHandler = web3.Eth.GetEvent<LogNoteEventDTO>(contractAddress);
            var logNoteEventFilter = logNoteEventHandler.CreateFilterInput(new object[] { methodSignatureByteArray }, BlockParameter.CreateEarliest(), BlockParameter.CreateLatest());
            var logNoteEventLogs = await logNoteEventHandler.GetAllChanges(logNoteEventFilter);

            Console.WriteLine("End.");
            Console.ReadKey();
        }
    }
}
