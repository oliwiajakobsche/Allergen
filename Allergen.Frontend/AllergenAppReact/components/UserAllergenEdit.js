import * as React from 'react';
import {View, Text, ActivityIndicator, Switch, StyleSheet, AppRegistry} from 'react-native';
import styles from './styles/UserAllergenEditStyle';
import { DeleteUserAllergensUrl, AddUserAllergensUrl } from '../ApiUrls';

class UserAllergenEdit extends React.Component {
        constructor(props) {
            super(props);
            this.state = {
                isToggled: false,
                isMounted: false
            }
        }      
     
        toggleSwitch = (value) => {
            if(this.state.isMounted == true)
            {        
                this.setState({isToggled : value});
                
                if(value)
                {
                    this.sendUserAllergenAddRequest();
                }
                else{
                    this.sendUserAllergenDeleteRequest();
                }
                console.log("Changed state");
            }
        };
     
        componentDidMount = () => {
            this.setState({isToggled: (this.props.userAllergenId > 0 ? true : false)})
            console.log("Component mounted");
            this.setState({isMounted: true})
        }

        render() {            
            return(
                <View style={styles.container}>
                    <Text style={styles.label}>{this.props.allergenName}</Text>
                    <Switch style={styles.switch} onValueChange={this.toggleSwitch} value={this.state.isToggled}></Switch>
                </View>
            )
        }

        sendUserAllergenAddRequest () {
            const url = AddUserAllergensUrl;
    
            console.log("Alergen do dodania.");
            console.log(url);
            fetch(url, { method: 'POST',
                headers: { 'Content-type': 'application/json; charset=UTF-8'},
                body: JSON.stringify({AllergenId: this.props.allergenId, UserId: 1})
            })
            .then(response => response.json())
            .then(data => console.log(data))
            .catch(err => console.log(err))
    
            console.log("Alergen dodano.");
          };
    
          sendUserAllergenDeleteRequest () {
    
            console.log("Alergen do usunięcia");
    
            const url = DeleteUserAllergensUrl + this.props.userAllergenId;
            console.log(url);
            fetch(url, { method: 'DELETE',
                headers: { 'Content-type': 'application/json; charset=UTF-8'},
                body: JSON.stringify({userAllergenId: this.props.userAllergenId})
            })
            .then(response => response.json())
            .then(data => console.log(data))
            .catch(err => console.log(err))
    
            console.log("Alergen usunięsto.");
          }
}

export default UserAllergenEdit;