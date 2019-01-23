using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using CL.General.SaiTub.CQS;

namespace CL.General.SaiTub.Service
{
    public partial class SaiTubService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, SaiTubDeployment saiTubDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<SaiTubDeployment>().SendRequestAndWaitForReceiptAsync(saiTubDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, SaiTubDeployment saiTubDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<SaiTubDeployment>().SendRequestAsync(saiTubDeployment);
        }

        public static async Task<SaiTubService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, SaiTubDeployment saiTubDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, saiTubDeployment, cancellationTokenSource);
            return new SaiTubService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public SaiTubService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> JoinRequestAsync(JoinFunction joinFunction)
        {
             return ContractHandler.SendRequestAsync(joinFunction);
        }

        public Task<TransactionReceipt> JoinRequestAndWaitForReceiptAsync(JoinFunction joinFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(joinFunction, cancellationToken);
        }

        public Task<string> JoinRequestAsync(BigInteger wad)
        {
            var joinFunction = new JoinFunction();
                joinFunction.Wad = wad;
            
             return ContractHandler.SendRequestAsync(joinFunction);
        }

        public Task<TransactionReceipt> JoinRequestAndWaitForReceiptAsync(BigInteger wad, CancellationTokenSource cancellationToken = null)
        {
            var joinFunction = new JoinFunction();
                joinFunction.Wad = wad;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(joinFunction, cancellationToken);
        }

        public Task<string> SinQueryAsync(SinFunction sinFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SinFunction, string>(sinFunction, blockParameter);
        }

        
        public Task<string> SinQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SinFunction, string>(null, blockParameter);
        }

        public Task<string> SkrQueryAsync(SkrFunction skrFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SkrFunction, string>(skrFunction, blockParameter);
        }

        
        public Task<string> SkrQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SkrFunction, string>(null, blockParameter);
        }

        public Task<string> GovQueryAsync(GovFunction govFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GovFunction, string>(govFunction, blockParameter);
        }

        
        public Task<string> GovQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GovFunction, string>(null, blockParameter);
        }

        public Task<string> SetOwnerRequestAsync(SetOwnerFunction setOwnerFunction)
        {
             return ContractHandler.SendRequestAsync(setOwnerFunction);
        }

        public Task<TransactionReceipt> SetOwnerRequestAndWaitForReceiptAsync(SetOwnerFunction setOwnerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setOwnerFunction, cancellationToken);
        }

        public Task<string> SetOwnerRequestAsync(string owner_)
        {
            var setOwnerFunction = new SetOwnerFunction();
                setOwnerFunction.Owner_ = owner_;
            
             return ContractHandler.SendRequestAsync(setOwnerFunction);
        }

        public Task<TransactionReceipt> SetOwnerRequestAndWaitForReceiptAsync(string owner_, CancellationTokenSource cancellationToken = null)
        {
            var setOwnerFunction = new SetOwnerFunction();
                setOwnerFunction.Owner_ = owner_;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setOwnerFunction, cancellationToken);
        }

        public Task<BigInteger> EraQueryAsync(EraFunction eraFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EraFunction, BigInteger>(eraFunction, blockParameter);
        }

        
        public Task<BigInteger> EraQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EraFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> InkQueryAsync(InkFunction inkFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<InkFunction, BigInteger>(inkFunction, blockParameter);
        }

        
        public Task<BigInteger> InkQueryAsync(byte[] cup, BlockParameter blockParameter = null)
        {
            var inkFunction = new InkFunction();
                inkFunction.Cup = cup;
            
            return ContractHandler.QueryAsync<InkFunction, BigInteger>(inkFunction, blockParameter);
        }

        public Task<BigInteger> RhoQueryAsync(RhoFunction rhoFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RhoFunction, BigInteger>(rhoFunction, blockParameter);
        }

        
        public Task<BigInteger> RhoQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RhoFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> AirQueryAsync(AirFunction airFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AirFunction, BigInteger>(airFunction, blockParameter);
        }

        
        public Task<BigInteger> AirQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AirFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> RhiRequestAsync(RhiFunction rhiFunction)
        {
             return ContractHandler.SendRequestAsync(rhiFunction);
        }

        public Task<string> RhiRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RhiFunction>();
        }

        public Task<TransactionReceipt> RhiRequestAndWaitForReceiptAsync(RhiFunction rhiFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(rhiFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RhiRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RhiFunction>(null, cancellationToken);
        }

        public Task<string> FlowRequestAsync(FlowFunction flowFunction)
        {
             return ContractHandler.SendRequestAsync(flowFunction);
        }

        public Task<string> FlowRequestAsync()
        {
             return ContractHandler.SendRequestAsync<FlowFunction>();
        }

        public Task<TransactionReceipt> FlowRequestAndWaitForReceiptAsync(FlowFunction flowFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(flowFunction, cancellationToken);
        }

        public Task<TransactionReceipt> FlowRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<FlowFunction>(null, cancellationToken);
        }

        public Task<BigInteger> CapQueryAsync(CapFunction capFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CapFunction, BigInteger>(capFunction, blockParameter);
        }

        
        public Task<BigInteger> CapQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CapFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> BiteRequestAsync(BiteFunction biteFunction)
        {
             return ContractHandler.SendRequestAsync(biteFunction);
        }

        public Task<TransactionReceipt> BiteRequestAndWaitForReceiptAsync(BiteFunction biteFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(biteFunction, cancellationToken);
        }

        public Task<string> BiteRequestAsync(byte[] cup)
        {
            var biteFunction = new BiteFunction();
                biteFunction.Cup = cup;
            
             return ContractHandler.SendRequestAsync(biteFunction);
        }

        public Task<TransactionReceipt> BiteRequestAndWaitForReceiptAsync(byte[] cup, CancellationTokenSource cancellationToken = null)
        {
            var biteFunction = new BiteFunction();
                biteFunction.Cup = cup;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(biteFunction, cancellationToken);
        }

        public Task<string> DrawRequestAsync(DrawFunction drawFunction)
        {
             return ContractHandler.SendRequestAsync(drawFunction);
        }

        public Task<TransactionReceipt> DrawRequestAndWaitForReceiptAsync(DrawFunction drawFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(drawFunction, cancellationToken);
        }

        public Task<string> DrawRequestAsync(byte[] cup, BigInteger wad)
        {
            var drawFunction = new DrawFunction();
                drawFunction.Cup = cup;
                drawFunction.Wad = wad;
            
             return ContractHandler.SendRequestAsync(drawFunction);
        }

        public Task<TransactionReceipt> DrawRequestAndWaitForReceiptAsync(byte[] cup, BigInteger wad, CancellationTokenSource cancellationToken = null)
        {
            var drawFunction = new DrawFunction();
                drawFunction.Cup = cup;
                drawFunction.Wad = wad;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(drawFunction, cancellationToken);
        }

        public Task<BigInteger> BidQueryAsync(BidFunction bidFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BidFunction, BigInteger>(bidFunction, blockParameter);
        }

        
        public Task<BigInteger> BidQueryAsync(BigInteger wad, BlockParameter blockParameter = null)
        {
            var bidFunction = new BidFunction();
                bidFunction.Wad = wad;
            
            return ContractHandler.QueryAsync<BidFunction, BigInteger>(bidFunction, blockParameter);
        }

        public Task<BigInteger> CupiQueryAsync(CupiFunction cupiFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CupiFunction, BigInteger>(cupiFunction, blockParameter);
        }

        
        public Task<BigInteger> CupiQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CupiFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> AxeQueryAsync(AxeFunction axeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AxeFunction, BigInteger>(axeFunction, blockParameter);
        }

        
        public Task<BigInteger> AxeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AxeFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> TagQueryAsync(TagFunction tagFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TagFunction, BigInteger>(tagFunction, blockParameter);
        }

        
        public Task<BigInteger> TagQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TagFunction, BigInteger>(null, blockParameter);
        }

        public Task<bool> OffQueryAsync(OffFunction offFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OffFunction, bool>(offFunction, blockParameter);
        }

        
        public Task<bool> OffQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OffFunction, bool>(null, blockParameter);
        }

        public Task<string> VoxQueryAsync(VoxFunction voxFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VoxFunction, string>(voxFunction, blockParameter);
        }

        
        public Task<string> VoxQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VoxFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> GapQueryAsync(GapFunction gapFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GapFunction, BigInteger>(gapFunction, blockParameter);
        }

        
        public Task<BigInteger> GapQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GapFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> RapRequestAsync(RapFunction rapFunction)
        {
             return ContractHandler.SendRequestAsync(rapFunction);
        }

        public Task<TransactionReceipt> RapRequestAndWaitForReceiptAsync(RapFunction rapFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(rapFunction, cancellationToken);
        }

        public Task<string> RapRequestAsync(byte[] cup)
        {
            var rapFunction = new RapFunction();
                rapFunction.Cup = cup;
            
             return ContractHandler.SendRequestAsync(rapFunction);
        }

        public Task<TransactionReceipt> RapRequestAndWaitForReceiptAsync(byte[] cup, CancellationTokenSource cancellationToken = null)
        {
            var rapFunction = new RapFunction();
                rapFunction.Cup = cup;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(rapFunction, cancellationToken);
        }

        public Task<string> WipeRequestAsync(WipeFunction wipeFunction)
        {
             return ContractHandler.SendRequestAsync(wipeFunction);
        }

        public Task<TransactionReceipt> WipeRequestAndWaitForReceiptAsync(WipeFunction wipeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(wipeFunction, cancellationToken);
        }

        public Task<string> WipeRequestAsync(byte[] cup, BigInteger wad)
        {
            var wipeFunction = new WipeFunction();
                wipeFunction.Cup = cup;
                wipeFunction.Wad = wad;
            
             return ContractHandler.SendRequestAsync(wipeFunction);
        }

        public Task<TransactionReceipt> WipeRequestAndWaitForReceiptAsync(byte[] cup, BigInteger wad, CancellationTokenSource cancellationToken = null)
        {
            var wipeFunction = new WipeFunction();
                wipeFunction.Cup = cup;
                wipeFunction.Wad = wad;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(wipeFunction, cancellationToken);
        }

        public Task<string> SetAuthorityRequestAsync(SetAuthorityFunction setAuthorityFunction)
        {
             return ContractHandler.SendRequestAsync(setAuthorityFunction);
        }

        public Task<TransactionReceipt> SetAuthorityRequestAndWaitForReceiptAsync(SetAuthorityFunction setAuthorityFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAuthorityFunction, cancellationToken);
        }

        public Task<string> SetAuthorityRequestAsync(string authority_)
        {
            var setAuthorityFunction = new SetAuthorityFunction();
                setAuthorityFunction.Authority_ = authority_;
            
             return ContractHandler.SendRequestAsync(setAuthorityFunction);
        }

        public Task<TransactionReceipt> SetAuthorityRequestAndWaitForReceiptAsync(string authority_, CancellationTokenSource cancellationToken = null)
        {
            var setAuthorityFunction = new SetAuthorityFunction();
                setAuthorityFunction.Authority_ = authority_;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAuthorityFunction, cancellationToken);
        }

        public Task<string> GemQueryAsync(GemFunction gemFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GemFunction, string>(gemFunction, blockParameter);
        }

        
        public Task<string> GemQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GemFunction, string>(null, blockParameter);
        }

        public Task<string> TurnRequestAsync(TurnFunction turnFunction)
        {
             return ContractHandler.SendRequestAsync(turnFunction);
        }

        public Task<TransactionReceipt> TurnRequestAndWaitForReceiptAsync(TurnFunction turnFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(turnFunction, cancellationToken);
        }

        public Task<string> TurnRequestAsync(string tap_)
        {
            var turnFunction = new TurnFunction();
                turnFunction.Tap_ = tap_;
            
             return ContractHandler.SendRequestAsync(turnFunction);
        }

        public Task<TransactionReceipt> TurnRequestAndWaitForReceiptAsync(string tap_, CancellationTokenSource cancellationToken = null)
        {
            var turnFunction = new TurnFunction();
                turnFunction.Tap_ = tap_;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(turnFunction, cancellationToken);
        }

        public Task<BigInteger> PerQueryAsync(PerFunction perFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PerFunction, BigInteger>(perFunction, blockParameter);
        }

        
        public Task<BigInteger> PerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PerFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> ExitRequestAsync(ExitFunction exitFunction)
        {
             return ContractHandler.SendRequestAsync(exitFunction);
        }

        public Task<TransactionReceipt> ExitRequestAndWaitForReceiptAsync(ExitFunction exitFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(exitFunction, cancellationToken);
        }

        public Task<string> ExitRequestAsync(BigInteger wad)
        {
            var exitFunction = new ExitFunction();
                exitFunction.Wad = wad;
            
             return ContractHandler.SendRequestAsync(exitFunction);
        }

        public Task<TransactionReceipt> ExitRequestAndWaitForReceiptAsync(BigInteger wad, CancellationTokenSource cancellationToken = null)
        {
            var exitFunction = new ExitFunction();
                exitFunction.Wad = wad;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(exitFunction, cancellationToken);
        }

        public Task<string> SetPipRequestAsync(SetPipFunction setPipFunction)
        {
             return ContractHandler.SendRequestAsync(setPipFunction);
        }

        public Task<TransactionReceipt> SetPipRequestAndWaitForReceiptAsync(SetPipFunction setPipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPipFunction, cancellationToken);
        }

        public Task<string> SetPipRequestAsync(string pip_)
        {
            var setPipFunction = new SetPipFunction();
                setPipFunction.Pip_ = pip_;
            
             return ContractHandler.SendRequestAsync(setPipFunction);
        }

        public Task<TransactionReceipt> SetPipRequestAndWaitForReceiptAsync(string pip_, CancellationTokenSource cancellationToken = null)
        {
            var setPipFunction = new SetPipFunction();
                setPipFunction.Pip_ = pip_;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPipFunction, cancellationToken);
        }

        public Task<BigInteger> PieQueryAsync(PieFunction pieFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PieFunction, BigInteger>(pieFunction, blockParameter);
        }

        
        public Task<BigInteger> PieQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PieFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> CageRequestAsync(CageFunction cageFunction)
        {
             return ContractHandler.SendRequestAsync(cageFunction);
        }

        public Task<TransactionReceipt> CageRequestAndWaitForReceiptAsync(CageFunction cageFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cageFunction, cancellationToken);
        }

        public Task<string> CageRequestAsync(BigInteger fit_, BigInteger jam)
        {
            var cageFunction = new CageFunction();
                cageFunction.Fit_ = fit_;
                cageFunction.Jam = jam;
            
             return ContractHandler.SendRequestAsync(cageFunction);
        }

        public Task<TransactionReceipt> CageRequestAndWaitForReceiptAsync(BigInteger fit_, BigInteger jam, CancellationTokenSource cancellationToken = null)
        {
            var cageFunction = new CageFunction();
                cageFunction.Fit_ = fit_;
                cageFunction.Jam = jam;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cageFunction, cancellationToken);
        }

        public Task<BigInteger> RumQueryAsync(RumFunction rumFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RumFunction, BigInteger>(rumFunction, blockParameter);
        }

        
        public Task<BigInteger> RumQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RumFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> SaiQueryAsync(SaiFunction saiFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SaiFunction, string>(saiFunction, blockParameter);
        }

        
        public Task<string> SaiQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SaiFunction, string>(null, blockParameter);
        }

        public Task<string> MoldRequestAsync(MoldFunction moldFunction)
        {
             return ContractHandler.SendRequestAsync(moldFunction);
        }

        public Task<TransactionReceipt> MoldRequestAndWaitForReceiptAsync(MoldFunction moldFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(moldFunction, cancellationToken);
        }

        public Task<string> MoldRequestAsync(byte[] param, BigInteger val)
        {
            var moldFunction = new MoldFunction();
                moldFunction.Param = param;
                moldFunction.Val = val;
            
             return ContractHandler.SendRequestAsync(moldFunction);
        }

        public Task<TransactionReceipt> MoldRequestAndWaitForReceiptAsync(byte[] param, BigInteger val, CancellationTokenSource cancellationToken = null)
        {
            var moldFunction = new MoldFunction();
                moldFunction.Param = param;
                moldFunction.Val = val;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(moldFunction, cancellationToken);
        }

        public Task<BigInteger> TaxQueryAsync(TaxFunction taxFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TaxFunction, BigInteger>(taxFunction, blockParameter);
        }

        
        public Task<BigInteger> TaxQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TaxFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> DripRequestAsync(DripFunction dripFunction)
        {
             return ContractHandler.SendRequestAsync(dripFunction);
        }

        public Task<string> DripRequestAsync()
        {
             return ContractHandler.SendRequestAsync<DripFunction>();
        }

        public Task<TransactionReceipt> DripRequestAndWaitForReceiptAsync(DripFunction dripFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(dripFunction, cancellationToken);
        }

        public Task<TransactionReceipt> DripRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<DripFunction>(null, cancellationToken);
        }

        public Task<string> FreeRequestAsync(FreeFunction freeFunction)
        {
             return ContractHandler.SendRequestAsync(freeFunction);
        }

        public Task<TransactionReceipt> FreeRequestAndWaitForReceiptAsync(FreeFunction freeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(freeFunction, cancellationToken);
        }

        public Task<string> FreeRequestAsync(byte[] cup, BigInteger wad)
        {
            var freeFunction = new FreeFunction();
                freeFunction.Cup = cup;
                freeFunction.Wad = wad;
            
             return ContractHandler.SendRequestAsync(freeFunction);
        }

        public Task<TransactionReceipt> FreeRequestAndWaitForReceiptAsync(byte[] cup, BigInteger wad, CancellationTokenSource cancellationToken = null)
        {
            var freeFunction = new FreeFunction();
                freeFunction.Cup = cup;
                freeFunction.Wad = wad;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(freeFunction, cancellationToken);
        }

        public Task<BigInteger> MatQueryAsync(MatFunction matFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MatFunction, BigInteger>(matFunction, blockParameter);
        }

        
        public Task<BigInteger> MatQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MatFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> PepQueryAsync(PepFunction pepFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PepFunction, string>(pepFunction, blockParameter);
        }

        
        public Task<string> PepQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PepFunction, string>(null, blockParameter);
        }

        public Task<bool> OutQueryAsync(OutFunction outFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OutFunction, bool>(outFunction, blockParameter);
        }

        
        public Task<bool> OutQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OutFunction, bool>(null, blockParameter);
        }

        public Task<string> LockRequestAsync(LockFunction lockFunction)
        {
             return ContractHandler.SendRequestAsync(lockFunction);
        }

        public Task<TransactionReceipt> LockRequestAndWaitForReceiptAsync(LockFunction lockFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(lockFunction, cancellationToken);
        }

        public Task<string> LockRequestAsync(byte[] cup, BigInteger wad)
        {
            var lockFunction = new LockFunction();
                lockFunction.Cup = cup;
                lockFunction.Wad = wad;
            
             return ContractHandler.SendRequestAsync(lockFunction);
        }

        public Task<TransactionReceipt> LockRequestAndWaitForReceiptAsync(byte[] cup, BigInteger wad, CancellationTokenSource cancellationToken = null)
        {
            var lockFunction = new LockFunction();
                lockFunction.Cup = cup;
                lockFunction.Wad = wad;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(lockFunction, cancellationToken);
        }

        public Task<string> ShutRequestAsync(ShutFunction shutFunction)
        {
             return ContractHandler.SendRequestAsync(shutFunction);
        }

        public Task<TransactionReceipt> ShutRequestAndWaitForReceiptAsync(ShutFunction shutFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(shutFunction, cancellationToken);
        }

        public Task<string> ShutRequestAsync(byte[] cup)
        {
            var shutFunction = new ShutFunction();
                shutFunction.Cup = cup;
            
             return ContractHandler.SendRequestAsync(shutFunction);
        }

        public Task<TransactionReceipt> ShutRequestAndWaitForReceiptAsync(byte[] cup, CancellationTokenSource cancellationToken = null)
        {
            var shutFunction = new ShutFunction();
                shutFunction.Cup = cup;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(shutFunction, cancellationToken);
        }

        public Task<string> GiveRequestAsync(GiveFunction giveFunction)
        {
             return ContractHandler.SendRequestAsync(giveFunction);
        }

        public Task<TransactionReceipt> GiveRequestAndWaitForReceiptAsync(GiveFunction giveFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(giveFunction, cancellationToken);
        }

        public Task<string> GiveRequestAsync(byte[] cup, string guy)
        {
            var giveFunction = new GiveFunction();
                giveFunction.Cup = cup;
                giveFunction.Guy = guy;
            
             return ContractHandler.SendRequestAsync(giveFunction);
        }

        public Task<TransactionReceipt> GiveRequestAndWaitForReceiptAsync(byte[] cup, string guy, CancellationTokenSource cancellationToken = null)
        {
            var giveFunction = new GiveFunction();
                giveFunction.Cup = cup;
                giveFunction.Guy = guy;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(giveFunction, cancellationToken);
        }

        public Task<string> AuthorityQueryAsync(AuthorityFunction authorityFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AuthorityFunction, string>(authorityFunction, blockParameter);
        }

        
        public Task<string> AuthorityQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AuthorityFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> FitQueryAsync(FitFunction fitFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FitFunction, BigInteger>(fitFunction, blockParameter);
        }

        
        public Task<BigInteger> FitQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FitFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> ChiRequestAsync(ChiFunction chiFunction)
        {
             return ContractHandler.SendRequestAsync(chiFunction);
        }

        public Task<string> ChiRequestAsync()
        {
             return ContractHandler.SendRequestAsync<ChiFunction>();
        }

        public Task<TransactionReceipt> ChiRequestAndWaitForReceiptAsync(ChiFunction chiFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(chiFunction, cancellationToken);
        }

        public Task<TransactionReceipt> ChiRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<ChiFunction>(null, cancellationToken);
        }

        public Task<string> SetVoxRequestAsync(SetVoxFunction setVoxFunction)
        {
             return ContractHandler.SendRequestAsync(setVoxFunction);
        }

        public Task<TransactionReceipt> SetVoxRequestAndWaitForReceiptAsync(SetVoxFunction setVoxFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setVoxFunction, cancellationToken);
        }

        public Task<string> SetVoxRequestAsync(string vox_)
        {
            var setVoxFunction = new SetVoxFunction();
                setVoxFunction.Vox_ = vox_;
            
             return ContractHandler.SendRequestAsync(setVoxFunction);
        }

        public Task<TransactionReceipt> SetVoxRequestAndWaitForReceiptAsync(string vox_, CancellationTokenSource cancellationToken = null)
        {
            var setVoxFunction = new SetVoxFunction();
                setVoxFunction.Vox_ = vox_;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setVoxFunction, cancellationToken);
        }

        public Task<string> PipQueryAsync(PipFunction pipFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PipFunction, string>(pipFunction, blockParameter);
        }

        
        public Task<string> PipQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PipFunction, string>(null, blockParameter);
        }

        public Task<string> SetPepRequestAsync(SetPepFunction setPepFunction)
        {
             return ContractHandler.SendRequestAsync(setPepFunction);
        }

        public Task<TransactionReceipt> SetPepRequestAndWaitForReceiptAsync(SetPepFunction setPepFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPepFunction, cancellationToken);
        }

        public Task<string> SetPepRequestAsync(string pep_)
        {
            var setPepFunction = new SetPepFunction();
                setPepFunction.Pep_ = pep_;
            
             return ContractHandler.SendRequestAsync(setPepFunction);
        }

        public Task<TransactionReceipt> SetPepRequestAndWaitForReceiptAsync(string pep_, CancellationTokenSource cancellationToken = null)
        {
            var setPepFunction = new SetPepFunction();
                setPepFunction.Pep_ = pep_;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPepFunction, cancellationToken);
        }

        public Task<BigInteger> FeeQueryAsync(FeeFunction feeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FeeFunction, BigInteger>(feeFunction, blockParameter);
        }

        
        public Task<BigInteger> FeeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FeeFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> LadQueryAsync(LadFunction ladFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LadFunction, string>(ladFunction, blockParameter);
        }

        
        public Task<string> LadQueryAsync(byte[] cup, BlockParameter blockParameter = null)
        {
            var ladFunction = new LadFunction();
                ladFunction.Cup = cup;
            
            return ContractHandler.QueryAsync<LadFunction, string>(ladFunction, blockParameter);
        }

        public Task<string> DinRequestAsync(DinFunction dinFunction)
        {
             return ContractHandler.SendRequestAsync(dinFunction);
        }

        public Task<string> DinRequestAsync()
        {
             return ContractHandler.SendRequestAsync<DinFunction>();
        }

        public Task<TransactionReceipt> DinRequestAndWaitForReceiptAsync(DinFunction dinFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(dinFunction, cancellationToken);
        }

        public Task<TransactionReceipt> DinRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<DinFunction>(null, cancellationToken);
        }

        public Task<BigInteger> AskQueryAsync(AskFunction askFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AskFunction, BigInteger>(askFunction, blockParameter);
        }

        
        public Task<BigInteger> AskQueryAsync(BigInteger wad, BlockParameter blockParameter = null)
        {
            var askFunction = new AskFunction();
                askFunction.Wad = wad;
            
            return ContractHandler.QueryAsync<AskFunction, BigInteger>(askFunction, blockParameter);
        }

        public Task<string> SafeRequestAsync(SafeFunction safeFunction)
        {
             return ContractHandler.SendRequestAsync(safeFunction);
        }

        public Task<TransactionReceipt> SafeRequestAndWaitForReceiptAsync(SafeFunction safeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeFunction, cancellationToken);
        }

        public Task<string> SafeRequestAsync(byte[] cup)
        {
            var safeFunction = new SafeFunction();
                safeFunction.Cup = cup;
            
             return ContractHandler.SendRequestAsync(safeFunction);
        }

        public Task<TransactionReceipt> SafeRequestAndWaitForReceiptAsync(byte[] cup, CancellationTokenSource cancellationToken = null)
        {
            var safeFunction = new SafeFunction();
                safeFunction.Cup = cup;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeFunction, cancellationToken);
        }

        public Task<string> PitQueryAsync(PitFunction pitFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PitFunction, string>(pitFunction, blockParameter);
        }

        
        public Task<string> PitQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PitFunction, string>(null, blockParameter);
        }

        public Task<string> TabRequestAsync(TabFunction tabFunction)
        {
             return ContractHandler.SendRequestAsync(tabFunction);
        }

        public Task<TransactionReceipt> TabRequestAndWaitForReceiptAsync(TabFunction tabFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(tabFunction, cancellationToken);
        }

        public Task<string> TabRequestAsync(byte[] cup)
        {
            var tabFunction = new TabFunction();
                tabFunction.Cup = cup;
            
             return ContractHandler.SendRequestAsync(tabFunction);
        }

        public Task<TransactionReceipt> TabRequestAndWaitForReceiptAsync(byte[] cup, CancellationTokenSource cancellationToken = null)
        {
            var tabFunction = new TabFunction();
                tabFunction.Cup = cup;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(tabFunction, cancellationToken);
        }

        public Task<string> OpenRequestAsync(OpenFunction openFunction)
        {
             return ContractHandler.SendRequestAsync(openFunction);
        }

        public Task<string> OpenRequestAsync()
        {
             return ContractHandler.SendRequestAsync<OpenFunction>();
        }

        public Task<TransactionReceipt> OpenRequestAndWaitForReceiptAsync(OpenFunction openFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(openFunction, cancellationToken);
        }

        public Task<TransactionReceipt> OpenRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<OpenFunction>(null, cancellationToken);
        }

        public Task<string> TapQueryAsync(TapFunction tapFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TapFunction, string>(tapFunction, blockParameter);
        }

        
        public Task<string> TapQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TapFunction, string>(null, blockParameter);
        }

        public Task<CupsOutputDTO> CupsQueryAsync(CupsFunction cupsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<CupsFunction, CupsOutputDTO>(cupsFunction, blockParameter);
        }

        public Task<CupsOutputDTO> CupsQueryAsync(byte[] returnValue1, BlockParameter blockParameter = null)
        {
            var cupsFunction = new CupsFunction();
                cupsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<CupsFunction, CupsOutputDTO>(cupsFunction, blockParameter);
        }
    }
}
