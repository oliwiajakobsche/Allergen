import * as React from 'react';
import {View, Text, ActivityIndicator, Switch} from 'react-native';

const ApiUrlGetUserAllergens = 'http://127.0.0.1:5575/api/UserAllergens/1';

class ProfileScreen extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
          isLoading: true,
          dataSource: null,
        }
      }

      componentDidMount(){        
        return fetch(ApiUrlGetUserAllergens, {method: "GET",
        headers: {
          'Accept': 'application/json, text/plain, */*',
          'Content-Type': 'application/json'
        },})
        .then((response)=>response.json())
        .then( (responseJson) => {
          this.setState({
            isLoading: false,
            dataSource: responseJson,
          })
    
        })
        .catch((error) => {
          console.log(error);
        });
      }

      render() {
        if(this.state.isLoading)
        {
          return (
          <View>
            <ActivityIndicator/>
          </View>
          );
        }
        else {         
          let allergens = this.state.dataSource.map((val, key) => {
            return (
            <View key={key}>
              <Text>{val.allergenName}</Text>
            </View>
            )
          })
        return(
          <View>           
            {allergens}
          </View>
        )
        }
      }
}

export default ProfileScreen;