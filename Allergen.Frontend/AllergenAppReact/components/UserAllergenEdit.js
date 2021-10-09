import * as React from 'react';
import {View, Text, Switch} from 'react-native';
import styles from './styles/UserAllergenEditStyle';
import { DeleteUserAllergensUrl, AddUserAllergensUrl, UserId } from '../ApiUrls';

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
                else
                {
                    this.sendUserAllergenDeleteRequest();
                }
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
            const parametersJson = JSON.stringify({AllergenId: this.props.allergenId, UserId: UserId});

            console.log("Request to " + url + "with parameters \n" + parametersJson);
            
            let dataFromApi = fetch(url, { method: 'POST',
                headers: { 'Content-type': 'application/json; charset=UTF-8'},
                body: parametersJson
            })
            .then((response) => response)   
            .then(data => console.log(data))
            .catch(err => console.log(err))          
          };
    
          sendUserAllergenDeleteRequest () {
    
            const url = DeleteUserAllergensUrl;
            const parametersJson = JSON.stringify({allergenId: this.props.allergenId, userId: UserId});

            console.log("Request to " + url + "with parameters \n" + parametersJson);

            fetch(url, { method: 'DELETE',
                headers: { 'Content-type': 'application/json; charset=UTF-8'},
                body: parametersJson
            })
            .then(response => console.log(response))
            .catch(err => console.log(err))
          }
}

export default UserAllergenEdit;