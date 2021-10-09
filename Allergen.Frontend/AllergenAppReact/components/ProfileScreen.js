import * as React from 'react';
import {View, Text, ActivityIndicator, Switch, ListItem} from 'react-native';
import UserAllergenEdit from './UserAllergenEdit';
import { GetUserAllergensUrl } from '../ApiUrls';

class ProfileScreen extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
          isLoading: true,
          dataSource: null,
        }
      }

      componentDidMount(){        
        return this.getUserAllergensFromApi();
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
              <UserAllergenEdit allergenId={val.allergenId} allergenName={val.allergenName} userAllergenId={val.userAllergenId}></UserAllergenEdit>
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
      
      getUserAllergensFromApi () {
        return fetch(GetUserAllergensUrl, {method: "GET",
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
}

export default ProfileScreen;