import {StyleSheet} from 'react-native';

const styles = StyleSheet.create({
    container: {        
        flexDirection: 'row',
        padding: 5,
        paddingLeft: 15,
        paddingRight: 15,
        borderColor: 'rgba(208, 237, 201,1)',
        borderWidth: 1,
        backgroundColor: 'rgba(208, 237, 201,0.2)'
    },
    label: {      
        fontSize: 15,
        fontWeight: '500',
        color: 'rgba(31, 31, 31, 0.7)',
        flex: 1
    },
    switch: {    
        flex: 1
    },
  });

export default styles;