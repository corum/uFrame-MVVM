// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;


public partial class DataClassNode : System.ComponentModel.INotifyPropertyChanged {
    
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName){ PropertyChangedEventHandler handler = PropertyChanged; if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName)); }}

public interface IGameData : System.ComponentModel.INotifyPropertyChanged {
    
    
    FPSPlayerData PlayerData {
        get;
        set;
    }
}

public interface IFPSPlayerData : System.ComponentModel.INotifyPropertyChanged {
    
    
    String Health {
        get;
        set;
    }
}
